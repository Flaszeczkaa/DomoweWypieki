using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DomoweWypieki
{
    public partial class FormAddClient : Form
    {
        public FormAddClient()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // A. Czy pola nie są puste?
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Imię i nazwisko są obowiązkowe!");
                return;
            }

            // B. Walidacja Telefonu (Dokładnie 9 cyfr)
            // ^ - początek, \d{9} - dziewięć cyfr, $ - koniec
            if (!Regex.IsMatch(txtPhone.Text.Trim(), @"^\d{9}$"))
            {
                MessageBox.Show("Numer telefonu musi składać się z dokładnie 9 cyfr!", "Błąd formatu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            // C. Walidacja E-mail (Standardowy wzorzec)
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern))
            {
                MessageBox.Show("Wprowadź poprawny adres e-mail (np. nazwa@domena.pl)!", "Błąd formatu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // --- 2. ZAPIS DO BAZY (ADO.NET) ---
            string connectionString = @"Data Source=localhost;Initial Catalog=DomoweWypieki;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"INSERT INTO Klienci (Imie, Nazwisko, Email, Telefon) 
                           VALUES (@imie, @nazwisko, @email, @telefon)";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@imie", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@nazwisko", txtLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefon", txtPhone.Text.Trim());

                        connection.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Klient dodany pomyślnie!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd zapisu: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFirstName.Text) ||
        !string.IsNullOrWhiteSpace(txtLastName.Text) ||
        !string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                // 2. Jeśli pola nie są puste, pytamy o potwierdzenie
                DialogResult result = MessageBox.Show(
                    "Czy na pewno chcesz anulować? Wprowadzone dane klienta zostaną utracone.",
                    "Potwierdzenie",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.Close(); // Zamyka tylko to okno i wraca do FormCustomers
                }
            }
            else
            {
                // 3. Jeśli pola są puste, zamykamy bez pytania
                this.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_surename_Click(object sender, EventArgs e)
        {

        }

        private void lbl_name_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
