using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomoweWypieki
{
    public partial class FormCustomers : Form
    {
        private string connectionString = @"Data Source=localhost;Initial Catalog=DomoweWypieki;Integrated Security=True";

        private DataSet dsClients;
        private SqlDataAdapter adapter;
        private BindingSource bsClients = new BindingSource();

        public FormCustomers()
        {
            InitializeComponent();
        }

        private void LoadClients(string searchTerm)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Podstawa zapytania
                    string query = "SELECT IdKlienta, Imie, Nazwisko, Email, Telefon FROM Klienci";

                    // Jeśli użytkownik coś wpisał, dodajemy filtry
                    if (!string.IsNullOrWhiteSpace(searchTerm))
                    {
                        // Szukamy frazy w trzech różnych kolumnach (wymóg pkt 25 - logika wyszukiwania)
                        query += @" WHERE Imie LIKE @search 
                            OR Nazwisko LIKE @search 
                            OR Email LIKE @search";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parametr dodajemy tylko, gdy szukamy konkretnej frazy
                        if (!string.IsNullOrWhiteSpace(searchTerm))
                        {
                            command.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                        }

                        connection.Open();

                        // Używamy Adaptera i DataSet (wymóg pkt 3 i 7)
                        adapter = new SqlDataAdapter(command);
                        dsClients = new DataSet();
                        adapter.Fill(dsClients, "Klienci");

                        // Odświeżamy widok w tabeli
                        dgv_customers.DataSource = dsClients.Tables["Klienci"];

                        UstawWygladKlientow();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas wyszukiwania: " + ex.Message, "Błąd ADO.NET");
            }
        }

        private void UstawWygladKlientow()
        {
            if (dgv_customers.Columns.Count > 0)
            {
                dgv_customers.ReadOnly = true;
                dgv_customers.AllowUserToAddRows = false;
                dgv_customers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_customers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Ukrywamy techniczne ID, jeśli nie chcesz go pokazywać użytkownikowi
                if (dgv_customers.Columns.Contains("IdKlienta"))
                {
                    // Opcja 1: "Inteligentna" szerokość (dopasuje się do tekstu 'ID Klienta')
                    dgv_customers.Columns["IdKlienta"].HeaderText = "ID Klienta";
                    dgv_customers.Columns["IdKlienta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    // Opcja 2: Jeśli wolisz sztywną wartość, zmień 50 na np. 100
                    // dgvClients.Columns["IdKlienta"].Width = 100;

                    // Dodatkowo: wyśrodkowanie ID wygląda bardziej profesjonalnie
                    dgv_customers.Columns["IdKlienta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_customers.Columns["IdKlienta"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void lbl_search_criteria_Click(object sender, EventArgs e)
        {

        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            DialogResult wynik = MessageBox.Show("Czy na pewno chcesz zakończyć pracę i wrócić do menu?", "Powrót", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (wynik == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_add_customer_Click(object sender, EventArgs e)
        {
            FormAddClient addClientForm = new FormAddClient();
            this.Hide();
            addClientForm.ShowDialog();
            this.Show();

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string fraza = txt_search_user.Text.Trim();

            // Wywołujemy metodę. Jeśli fraza jest "", metoda LoadClients wyświetli wszystkich.
            LoadClients(fraza);
        }

        private void btn_delete_customer_Click(object sender, EventArgs e)
        {
            if (dgv_customers.SelectedRows.Count > 0)
            {
                // 2. Pobieramy ID i Nazwisko wybranego klienta
                var selectedRow = dgv_customers.SelectedRows[0];
                int idKlienta = Convert.ToInt32(selectedRow.Cells["IdKlienta"].Value);
                string nazwisko = selectedRow.Cells["Nazwisko"].Value.ToString();

                // 3. Pytamy o potwierdzenie (UX i reguła biznesowa)
                DialogResult result = MessageBox.Show(
                    $"Czy na pewno chcesz usunąć klienta: {nazwisko}? Operacja jest nieodwracalna.",
                    "Potwierdzenie usunięcia",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    UsunKlientaZBazy(idKlienta);
                }
            }
            else
            {
                MessageBox.Show("Proszę najpierw zaznaczyć klienta w tabeli.", "Informacja");
            }
        }

        private void UsunKlientaZBazy(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // 1. SPRAWDZAMY STATUSY ZAMÓWIEŃ (Reguła Biznesowa)
                    string sqlCheck = @"SELECT COUNT(*) FROM Zamowienia 
                                WHERE IdKlienta = @id 
                                AND Status IN ('Przyjęte', 'W realizacji')";

                    using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, connection))
                    {
                        cmdCheck.Parameters.AddWithValue("@id", id);
                        int aktywneZamowienia = (int)cmdCheck.ExecuteScalar();

                        if (aktywneZamowienia > 0)
                        {
                            MessageBox.Show("Nie można usunąć klienta! Ma on zamówienia w statusie 'Przyjęte' lub 'W realizacji'. \nZakończ lub anuluj zamówienia przed usunięciem klienta.",
                                            "Blokada usuwania", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return; // Przerywamy działanie metody
                        }
                    }

                    // 2. JEŚLI NIE MA AKTYWNYCH, PRÓBUJEMY USUNĄĆ
                    // (Jeśli są zamówienia 'Wydane', baza i tak może zablokować usuwanie przez FK)
                    string sqlDelete = "DELETE FROM Klienci WHERE IdKlienta = @id";

                    using (SqlCommand cmdDelete = new SqlCommand(sqlDelete, connection))
                    {
                        cmdDelete.Parameters.AddWithValue("@id", id);
                        cmdDelete.ExecuteNonQuery();

                        MessageBox.Show("Klient został usunięty.", "Sukces");
                        LoadClients("");
                    }
                }
            }
            catch (SqlException ex)
            {
                // Obsługa błędu więzów integralności (Pkt 10)
                if (ex.Number == 547)
                {
                    MessageBox.Show("Klient ma już archiwalne zamówienia (Wydane). \nBaza danych chroni historię sprzedaży i nie pozwala na jego całkowite usunięcie.",
                                    "Ochrona danych archiwalnych", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Błąd bazy danych: " + ex.Message);
                }
            }
        }

        private void dgv_customers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 1. Pobieramy dane z zaznaczonego wiersza
                int id = Convert.ToInt32(dgv_customers.Rows[e.RowIndex].Cells["IdKlienta"].Value);
                string imie = dgv_customers.Rows[e.RowIndex].Cells["Imie"].Value.ToString();
                string nazwisko = dgv_customers.Rows[e.RowIndex].Cells["Nazwisko"].Value.ToString();
                string email = dgv_customers.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                string telefon = dgv_customers.Rows[e.RowIndex].Cells["Telefon"].Value.ToString();

                // 2. Otwieramy okno edycji i przekazujemy dane przez konstruktor
                using (FormEditClient editForm = new FormEditClient(id, imie, nazwisko, email, telefon))
                {
                    editForm.StartPosition = FormStartPosition.Manual; 
                    editForm.Location = this.Location;
                    this.Hide();

                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        // 3. Jeśli zapisano zmiany, odświeżamy tabelę
                        LoadClients("");
                    }

                    this.Location = editForm.Location;
                    this.Show();
                }
            }
        }
    }
}
