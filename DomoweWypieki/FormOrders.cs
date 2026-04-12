using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;


namespace DomoweWypieki
{
    public partial class FormOrders : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DomoweWypiekiConn"].ConnectionString;

        private DataSet dsOrders;
        private SqlDataAdapter adapterOrders;
        private SqlDataAdapter adapterDetails;

        public FormOrders()
        {
            InitializeComponent();
            this.Load += FormOrders_Load;
        }

        private void FormOrders_Load(object sender, EventArgs e)
        {
            LoadData();

            dgv_Orders.CurrentCellDirtyStateChanged += dgv_Orders_CurrentCellDirtyStateChanged;
            dgv_Orders.CellValueChanged += dgv_Orders_CellValueChanged;
            dgv_Orders.DataError += dgv_Orders_DataError;
        }

        private void dgv_Orders_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgv_Orders.IsCurrentCellDirty && dgv_Orders.CurrentCell is DataGridViewComboBoxCell)
            {
                dgv_Orders.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgv_Orders_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_Orders.Columns[e.ColumnIndex].Name == "StatusCombo")
            {
                object statusValue = dgv_Orders.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                object orderIdValue = dgv_Orders.Rows[e.RowIndex].Cells["IdZamowienia"].Value;

                if (statusValue != DBNull.Value && orderIdValue != DBNull.Value)
                {
                    int newStatusId = Convert.ToInt32(statusValue);
                    int orderId = Convert.ToInt32(orderIdValue);

                    // --- TWOJA LOGIKA BLOKADY ---
                    if (newStatusId == 5) // 5 to ID statusu 'Anulowane'
                    {
                        DataRowView row = (DataRowView)bsOrders.Current;
                        // Sprawdzamy stan tekstowy sprzed zmiany zapisu
                        if (row["StatusTekst"].ToString() != "Przyjęte")
                        {
                            MessageBox.Show("Nie można anulować zamówienia, które nie jest w statusie 'Przyjęte'. " +
                                "\nUżyj przycisku 'Anuluj zamówienie' dla poprawnych operacji.",
                                "Blokada zmiany", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            // Cofamy zmianę w tabeli w pamięci
                            row.Row.RejectChanges();
                            return;
                        }
                    }

                    ZaktualizujStatusWBazie(orderId, newStatusId);
                }
            }
        }

        private void ZaktualizujStatusWBazie(int orderId, int newStatusId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = "UPDATE Zamowienia SET IdStatusu = @idStatusu WHERE IdZamowienia = @idZamowienia";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@idStatusu", newStatusId);
                        cmd.Parameters.AddWithValue("@idZamowienia", orderId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                // Aktualizacja powiodła się, warto zaktualizować pole StatusTekst w pamięci żeby działała wyszukiwarka
                DataRowView currentRow = (DataRowView)bsOrders.Current;
                DataTable dtStatusy = dsOrders.Tables["Statusy"];
                DataRow[] statusRow = dtStatusy.Select($"IdStatusu = {newStatusId}");
                if (statusRow.Length > 0)
                {
                    currentRow["StatusTekst"] = statusRow[0]["NazwaStatusu"];
                    currentRow.Row.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania statusu: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Zabezpieczenie na wypadek błędów powiązań danych w DGV
        private void dgv_Orders_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void LoadData()
        {
            try
            {
                dsOrders = new DataSet();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // 1. POBRANIE SŁOWNIKA STATUSÓW (dla ComboBoxa)
                    string sqlStatuses = "SELECT IdStatusu, NazwaStatusu FROM StatusyZamowien";
                    SqlDataAdapter adapterStatuses = new SqlDataAdapter(sqlStatuses, conn);
                    adapterStatuses.Fill(dsOrders, "Statusy");

                    // 2. MODYFIKACJA ZAPYTANIA O ZAMÓWIENIA (dodano z.IdStatusu oraz StatusTekst dla wyszukiwarki)
                    string sqlOrders = @"SELECT z.IdZamowienia, k.Imie + ' ' + k.Nazwisko as Klient, 
                                            z.IdStatusu, s.NazwaStatusu as StatusTekst, z.DataZlozenia, z.DataRealizacji, z.RabatProcent 
                                         FROM Zamowienia z 
                                         JOIN Klienci k ON z.IdKlienta = k.IdKlienta 
                                         JOIN StatusyZamowien s ON z.IdStatusu = s.IdStatusu";

                    adapterOrders = new SqlDataAdapter(sqlOrders, conn);
                    adapterOrders.Fill(dsOrders, "Zamowienia");

                    // zapytanie o konkretne ciasta w zamówieniu
                    string sqlDetails = @"SELECT pz.IdZamowienia, o.Nazwa as Produkt, pz.Ilosc, 
                                         pz.CenaBazowa, pz.CenaRazem 
                                         FROM PozycjeZamowienia pz 
                                         JOIN OfertaCukierni o ON pz.IdProduktu = o.IdProduktu";

                    adapterDetails = new SqlDataAdapter(sqlDetails, conn);
                    adapterDetails.Fill(dsOrders, "Pozycje");

                    //Tworzenie relacji w pamięci, łączy zamówienia ze szczegółami po kolumnie IdZamowienia
                    DataRelation relation = new DataRelation("OrderDetails",
                        dsOrders.Tables["Zamowienia"].Columns["IdZamowienia"],
                        dsOrders.Tables["Pozycje"].Columns["IdZamowienia"]);
                    dsOrders.Relations.Add(relation);

                    bsOrders.DataSource = dsOrders; // Źródło danych dla nawigatora i tabeli głównej
                    bsOrders.DataMember = "Zamowienia";

                    dgv_Orders.DataSource = bsOrders;
                    bnOrders.BindingSource = bsOrders;// Podpięcie nawigatora

                    // Logika dynamicznego odświeżania szczegółów
                    BindingSource bsDetails = new BindingSource();
                    bsDetails.DataSource = bsOrders;
                    bsDetails.DataMember = "OrderDetails";

                    dgv_OrderDetails.DataSource = bsDetails;
                }
                UstawWyglad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania danych: " + ex.Message);
            }
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            DialogResult wynik = MessageBox.Show("Czy na pewno chcesz zakończyć pracę i wrócić do menu?", "Powrót", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (wynik == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string phrase = txt_search_user.Text.Trim();
            // Filtrowanie po stronie BindingSource (bez ponownego odpytywania bazy - Disconnected)
            if (string.IsNullOrEmpty(phrase))
                bsOrders.RemoveFilter();
            else
                bsOrders.Filter = $"Klient LIKE '%{phrase}%' OR StatusTekst LIKE '%{phrase}%'";
        }
        private void UstawWyglad()
        {
            if (dgv_Orders.Columns.Count > 0)
            {
                // Ukrywamy kolumny z ID i starą tekstową kolumnę, która służy tylko do filtra
                if (dgv_Orders.Columns.Contains("IdStatusu")) dgv_Orders.Columns["IdStatusu"].Visible = false;
                if (dgv_Orders.Columns.Contains("StatusTekst")) dgv_Orders.Columns["StatusTekst"].Visible = false;

                // Tworzymy nową kolumnę z ComboBoxem (jeśli jeszcze jej nie ma)
                if (!dgv_Orders.Columns.Contains("StatusCombo"))
                {
                    DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
                    comboCol.Name = "StatusCombo";
                    comboCol.HeaderText = "Status";

                    // Konfiguracja źródła danych dla ComboBoxa
                    comboCol.DataSource = dsOrders.Tables["Statusy"];
                    comboCol.DisplayMember = "NazwaStatusu"; // to co widzi użytkownik
                    comboCol.ValueMember = "IdStatusu";      // to co idzie do bazy (wartość ID)
                    comboCol.DataPropertyName = "IdStatusu"; // powiązanie z naszą tabelą zamówień

                    comboCol.FlatStyle = FlatStyle.Flat; // Lepszy wygląd

                    // Wstawiamy kolumnę na 3 pozycję (indeks 2)
                    dgv_Orders.Columns.Insert(2, comboCol);
                }

                dgv_Orders.Columns["IdZamowienia"].HeaderText = "Nr Zam.";
                dgv_Orders.Columns["DataZlozenia"].HeaderText = "Złożono";
                dgv_Orders.Columns["DataRealizacji"].HeaderText = "Data Realizacji";
                dgv_Orders.Columns["RabatProcent"].DefaultCellStyle.Format = "P0";
                dgv_Orders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // --- KLUCZOWE ZMIANY DLA COMBOBOXA ---

                // 1. Ustawienie trybu edycji na "Od razu po wejściu" (jedno kliknięcie otwiera listę)
                dgv_Orders.EditMode = DataGridViewEditMode.EditOnEnter;

                // 2. Odblokowanie całej tabeli
                dgv_Orders.ReadOnly = false;

                // 3. Zablokowanie edycji dla wszystkich kolumn oprócz naszego ComboBoxa
                foreach (DataGridViewColumn col in dgv_Orders.Columns)
                {
                    if (col.Name != "StatusCombo")
                    {
                        col.ReadOnly = true;
                    }
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (bsOrders.Current == null)
            {
                MessageBox.Show("Proszę najpierw wybrać zamówienie z listy.", "Informacja");
                return;
            }

            DataRowView selectedRow = (DataRowView)bsOrders.Current;
            string currentStatus = selectedRow["Status Tekst"].ToString();

            if (currentStatus == "Przyjęte")
            {
                DialogResult confirm = MessageBox.Show(
                    "Czy na pewno chcesz anulować to zamówienie?",
                    "Potwierdzenie anulowania",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    int orderId = (int)selectedRow["IdZamowienia"];
                    AnulujZamowienie(orderId);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show(
                    $"Nie można anulować zamówienia w statusie '{currentStatus}'. \nMożliwe jest anulowanie wyłącznie zamówień o statusie 'Przyjęte'.",
                    "Blokada operacji",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void AnulujZamowienie(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = "UPDATE Zamowienia SET IdStatusu = 5 WHERE IdZamowienia = @id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Zamówienie zostało pomyślnie anulowane.", "Sukces");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas aktualizacji bazy: " + ex.Message, "Błąd");
            }
        }

        

        private void dgv_Orders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
