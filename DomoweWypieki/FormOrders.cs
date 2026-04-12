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
        }

        private void LoadData()
        {
            try
            {
                dsOrders = new DataSet();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sqlOrders = @"SELECT z.IdZamowienia, k.Imie + ' ' + k.Nazwisko as Klient, 
                                        s.NazwaStatusu as Status, z.DataZlozenia, z.DataRealizacji, z.RabatProcent 
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
                bsOrders.Filter = $"Klient LIKE '%{phrase}%' OR Status LIKE '%{phrase}%'";
        }
        private void UstawWyglad()
        {
            if (dgv_Orders.Columns.Count > 0)
            {
                dgv_Orders.Columns["IdZamowienia"].HeaderText = "Nr Zam.";
                dgv_Orders.Columns["DataZlozenia"].HeaderText = "Złożono";
                dgv_Orders.Columns["RabatProcent"].DefaultCellStyle.Format = "P0";
                dgv_Orders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            string currentStatus = selectedRow["Status"].ToString();

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
    }
}
