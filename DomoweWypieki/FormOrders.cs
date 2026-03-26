using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DomoweWypieki
{
    public partial class FormOrders : Form
    {
        private string connectionString = @"Data Source=localhost;Initial Catalog=DomoweWypieki;Integrated Security=True";

        private DataSet dsOrders;
        private SqlDataAdapter adapter;

        public FormOrders()
        {
            InitializeComponent();
            LoadOrders("");
        }

        private void LoadOrders(string searchTerm)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Budowanie zapytania SQL
                    string query = @"SELECT 
                                z.IdZamowienia, 
                                z.IdKlienta, 
                                z.DataZlozenia, 
                                z.DataRealizacji, 
                                z.Status, 
                                z.RabatProcent,
                                ISNULL(p.CenaBazowa + p.SumaDoplat, 0) AS [Cena Tortu]
                             FROM dbo.Zamowienia z
                             LEFT JOIN dbo.PozycjeZamowienia p ON z.IdZamowienia = p.IdZamowienia";

                    if (!string.IsNullOrWhiteSpace(searchTerm))
                    {
                        query += @" WHERE z.Status LIKE @search 
                            OR CAST(z.IdKlienta AS VARCHAR) LIKE @search 
                            OR CAST(z.IdZamowienia AS VARCHAR) LIKE @search";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrWhiteSpace(searchTerm))
                        {
                            command.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                        }

                        adapter = new SqlDataAdapter(command);
                        dsOrders = new DataSet();

                        adapter.Fill(dsOrders, "Zamowienia");

                        bsOrders.DataSource = dsOrders.Tables["Zamowienia"];
                        dgvOrders.DataSource = bsOrders;

                        // Przypisanie nawigatora do źródła danych
                        bnOrders.BindingSource = bsOrders;

                        UstawWygladTabeli();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd bazy danych: " + ex.Message, "Błąd ADO.NET");
            }
        }

        // Ta metoda naprawia błąd CS0103
        private void UstawWygladTabeli()
        {
            dgvOrders.ReadOnly = true;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Upewniamy się, że IdKlienta jest widoczne (zmień z false na true)
            if (dgvOrders.Columns.Contains("IdKlienta"))
                dgvOrders.Columns["IdKlienta"].Visible = true;

            // Opcjonalnie: popraw nagłówek nowej kolumny z ceną
            if (dgvOrders.Columns.Contains("Cena Tortu"))
            {
                dgvOrders.Columns["Cena Tortu"].DefaultCellStyle.Format = "C2"; // Format walutowy
                dgvOrders.Columns["Cena Tortu"].DefaultCellStyle.ForeColor = Color.DarkGreen;
            }
        }

        private void btn_search_user_Click(object sender, EventArgs e)
        {
            LoadOrders(txt_search_user.Text.Trim());
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            this.Tag = "back";
            this.Close();
        }


        private void FormOrders_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                // Pobieramy dane z zaznaczonego wiersza
                // Używamy nazw kolumn, które nadaliśmy w zapytaniu SQL (np. [Nr Zamówienia] i [Status])
                var selectedRow = dgvOrders.SelectedRows[0];
                int idOrder = Convert.ToInt32(selectedRow.Cells["IdZamowienia"].Value);
                string status = selectedRow.Cells["Status"].Value.ToString();

                // 2. Logika sprawdzania statusu
                if (status == "Przyjęte")
                {
                    // Pytamy dla pewności, czy na pewno usunąć (profesjonalny dodatek)
                    DialogResult result = MessageBox.Show($"Czy na pewno chcesz anulować i usunąć zamówienie nr {idOrder}?",
                        "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        DeleteOrder(idOrder);
                    }
                }
                else
                {
                    // 3. Komunikat, gdy zamówienie jest już w toku lub zakończone
                    MessageBox.Show($"Nie da się anulować tego zamówienia, ponieważ ma status: '{status}'.",
                        "Błąd anulowania", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Proszę najpierw wybrać zamówienie z tabeli.", "Informacja");
            }
        }
        private void DeleteOrder(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Usuwamy wszystko po kolei, od najniższego poziomu do głównego rekordu
                string query = @"
                    DELETE FROM dbo.PozycjeZamowienia WHERE IdZamowienia = @id;
                    DELETE FROM dbo.Platnosci WHERE IdZamowienia = @id;
                    DELETE FROM dbo.Zamowienia WHERE IdZamowienia = @id;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Zamówienie zostało pomyślnie anulowane i usunięte z całej bazy.", "Sukces");

                        // Odświeżamy tabelę główną
                        LoadOrders("");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Wystąpił nieoczekiwany błąd: " + ex.Message);
                    }
                }
            }
        }

        private void btn_add_order_Click(object sender, EventArgs e)
        {
            FormAddOrder neworderForm = new FormAddOrder();

            neworderForm.StartPosition = FormStartPosition.Manual;
            neworderForm.Location = this.Location;

            this.Hide();

            if (neworderForm.ShowDialog() == DialogResult.OK)
            {
                LoadOrders("");
            }

            //neworderForm.ShowDialog();

            this.Location = neworderForm.Location;

            this.Show();
        }
    }
}
