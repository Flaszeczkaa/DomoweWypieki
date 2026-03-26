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
    public partial class FormAddOrder : Form
    {
        private string connectionString = @"Data Source=localhost;Initial Catalog=DomoweWypieki;Integrated Security=True";

        private DataSet dsAddOrder = new DataSet();

        public FormAddOrder()
        {
            InitializeComponent();
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    // --- ŁADOWANIE KLIENTÓW ---
                    adapter.SelectCommand = new SqlCommand("SELECT IdKlienta, Nazwisko + ' ' + Imie AS Klient FROM Klienci", connection);
                    adapter.Fill(dsAddOrder, "Klienci"); // Wypełnianie DataSet 

                    cbCustomers.DataSource = dsAddOrder.Tables["Klienci"];
                    cbCustomers.DisplayMember = "Klient"; // To widzi użytkownik
                    cbCustomers.ValueMember = "IdKlienta"; // To zapiszemy w bazie

                    // --- ŁADOWANIE ROZMIARÓW TORTÓW ---
                    adapter.SelectCommand = new SqlCommand("SELECT IdRozmiaru, Rozmiar, CenaBazowa FROM TortRozmiary", connection);
                    adapter.Fill(dsAddOrder, "TortRozmiary"); // Zmiana nazwy tabeli w DataSet
                    cbCakeSize.DataSource = dsAddOrder.Tables["TortRozmiary"];
                    cbCakeSize.DisplayMember = "Rozmiar"; // Zmiana z NazwaRozmiaru na Rozmiar
                    cbCakeSize.ValueMember = "IdRozmiaru";

                    // --- ŁADOWANIE CIAST ---
                    adapter.SelectCommand = new SqlCommand("SELECT IdCiasta, Nazwa FROM Ciasta", connection);
                    adapter.Fill(dsAddOrder, "Ciasta");

                    cbCakes.DataSource = dsAddOrder.Tables["Ciasta"];
                    cbCakes.DisplayMember = "Nazwa";  // Musi być "Nazwa", nie "NazwaCiasta"! [cite: 13]
                    cbCakes.ValueMember = "IdCiasta";

                    // Resetowanie zaznaczenia na starcie
                    cbCustomers.SelectedIndex = -1;
                    cbCakeSize.SelectedIndex = -1;
                    cbCakes.SelectedIndex = -1;
                }
            }
            catch (Exception ex) // Obsługa wyjątków - wymóg pkt 10 [cite: 19]
            {
                MessageBox.Show("Błąd podczas ładowania list: " + ex.Message);
            }
        }
        private void btn_price_Click(object sender, EventArgs e)
        {
            decimal suma = 0;

            // 1. Sprawdzamy ROZMIAR TORTU (Tabela: TortRozmiary)
            if (cbCakeSize.SelectedValue != null)
            {
                // Próbujemy pobrać ID (używamy TryParse dla bezpieczeństwa)
                if (int.TryParse(cbCakeSize.SelectedValue.ToString(), out int idR))
                {
                    // WAŻNE: Upewnij się, że nazwa "TortRozmiary" jest identyczna jak w LoadComboBoxData!
                    DataRow[] rows = dsAddOrder.Tables["TortRozmiary"].Select("IdRozmiaru = " + idR);

                    if (rows.Length > 0)
                    {
                        suma += Convert.ToDecimal(rows[0]["CenaBazowa"]);
                    }
                }
            }

            // 2. Sprawdzamy RODZAJ CIASTA (Tabela: Ciasta)
            if (cbCakes.SelectedValue != null)
            {
                if (int.TryParse(cbCakes.SelectedValue.ToString(), out int idC))
                {
                    DataRow[] rows = dsAddOrder.Tables["Ciasta"].Select("IdCiasta = " + idC);
                    if (rows.Length > 0)
                    {
                        suma += Convert.ToDecimal(rows[0]["CenaJednostkowa"]);
                    }
                }
            }

            // 3. Dodajemy dopłaty za CheckBoxy (Twoja logika biznesowa)
            if (chbDecorationPremium.Checked) suma += 50.00m;
            if (chbTopperPremium.Checked) suma += 30.00m;
            if (chbTastePremium.Checked) suma += 45.00m;

            // 4. NAKŁADAMY RABAT (max 20%)
            decimal rabatProcent = nudDiscount.Value;
            if (rabatProcent > 20) rabatProcent = 20; // Blokada reguły biznesowej

            decimal mnoznik = (100 - rabatProcent) / 100;
            suma = suma * mnoznik;

            // 5. Wyświetlanie wyniku z formatowaniem (zł na końcu)
            txtTotalPrice.Text = suma.ToString("0.00") + " zł";
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (cbCustomers.SelectedIndex != -1 || cbCakeSize.SelectedIndex != -1 || cbCakes.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show(
                    "Czy na pewno chcesz anulować dodawanie zamówienia? Wprowadzone dane zostaną utracone.",
                    "Potwierdzenie",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btn_add_order_Click(object sender, EventArgs e)
        {
            // 1. Walidacja ogólna: Czy formularz jest kompletnie pusty?
            if (cbCustomers.SelectedIndex == -1 && cbCakeSize.SelectedIndex == -1 && cbCakes.SelectedIndex == -1)
            {
                MessageBox.Show("Brak danych do zapisu!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Walidacje szczegółowe (Reguły biznesowe - pkt 25) 
            if (cbCustomers.SelectedValue == null)
            {
                MessageBox.Show("Proszę wybrać klienta!", "Brak klienta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbCakeSize.SelectedValue == null && cbCakes.SelectedValue == null)
            {
                MessageBox.Show("Musisz wybrać przynajmniej jeden produkt (tort lub ciasto)!", "Brak produktu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbCakes.SelectedValue == null)
            {
                MessageBox.Show("Proszę wybrać rodzaj ciasta/smak!", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpOrderDate.Value.Date >= dtpRealizationDate.Value.Date)
            {
                MessageBox.Show("Data realizacji musi być późniejsza niż data złożenia zamówienia!", "Błąd daty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudDiscount.Value > 20)
            {
                MessageBox.Show("Rabat nie może przekraczać 20%. Proszę poprawić dane.", "Błąd walidacji");
                return;
            }

            // 3. ROZWIĄZANIE BŁĘDU FORMATU: Czyścimy cenę z dopisku " zł"
            decimal cenaFinalna;
            string tekstCeny = txtTotalPrice.Text.Replace(" zł", "").Trim();

            if (!decimal.TryParse(tekstCeny, out cenaFinalna))
            {
                MessageBox.Show("Błąd formatu ceny. Kliknij 'Oblicz kwotę' przed zapisem.");
                return;
            }

            // 4. Zapis do bazy (Obsługa wyjątków - pkt 10) 
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // KROK A: Uzupełnianie (pkt 8b) - Tabela Zamowienia [cite: 16]
                        string sqlOrder = @"INSERT INTO Zamowienia 
                    (IdKlienta, DataZlozenia, DataRealizacji, Status, RabatProcent) 
                    VALUES (@idK, @dataZ, @dataR, 'Nowe', 0);
                    SELECT SCOPE_IDENTITY();";

                        int newOrderId;
                        using (SqlCommand cmd = new SqlCommand(sqlOrder, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@idK", cbCustomers.SelectedValue);
                            cmd.Parameters.AddWithValue("@dataZ", dtpOrderDate.Value);
                            cmd.Parameters.AddWithValue("@dataR", dtpRealizationDate.Value);
                            cmd.Parameters.AddWithValue("@suma", cenaFinalna);
                            newOrderId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // KROK B: Pozycja zamówienia
                        string sqlItem = @"INSERT INTO PozycjeZamowienia 
                    (IdZamowienia, TypPozycji, IdCiasta, IdRozmiaruTortu, Ilosc, CenaBazowa, SumaDoplat) 
                    VALUES (@idZ, @typ, @idC, @idR, 1, @cena, @dop);";

                        using (SqlCommand cmdItem = new SqlCommand(sqlItem, connection, transaction))
                        {
                            cmdItem.Parameters.AddWithValue("@idZ", newOrderId);
                            cmdItem.Parameters.AddWithValue("@typ", cbCakeSize.SelectedIndex != -1 ? "Tort" : "Ciasto");
                            cmdItem.Parameters.AddWithValue("@idC", cbCakes.SelectedValue ?? DBNull.Value);
                            cmdItem.Parameters.AddWithValue("@idR", cbCakeSize.SelectedValue ?? DBNull.Value);
                            cmdItem.Parameters.AddWithValue("@cena", cenaFinalna);
                            cmdItem.Parameters.AddWithValue("@dop", 0);
                            cmdItem.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Zamówienie nr " + newOrderId + " zostało pomyślnie utworzone!", "Sukces");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ADO.NET: " + ex.Message);
            }
        }
    }
}
