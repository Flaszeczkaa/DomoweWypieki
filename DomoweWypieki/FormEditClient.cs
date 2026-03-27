using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomoweWypieki
{
    public partial class FormEditClient : Form
    {
        private int clientId;
        string connectionString = @"Data Source=localhost;Initial Catalog=DomoweWypieki;Integrated Security=True";

        // Konstruktor przyjmujący dane klienta
        public FormEditClient(int id, string imie, string nazwisko, string email, string telefon)
        {
            InitializeComponent();
            clientId = id;
            txtFirstName.Text = imie;
            txtLastName.Text = nazwisko;
            txtEmail.Text = email;
            txtPhone.Text = telefon;
        }

        public FormEditClient()
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

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"UPDATE Klienci 
                               SET Imie = @imie, Nazwisko = @nazwisko, Email = @email, Telefon = @telefon 
                               WHERE IdKlienta = @id";

                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@imie", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@nazwisko", txtLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@telefon", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", clientId);

                        connection.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Dane klienta zostały zaktualizowane!");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd edycji: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Czy na pewno chcesz przerwać edycję? Wszystkie wprowadzone zmiany zostaną utracone.",
                "Anulowanie zmian",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Ustawiamy Cancel, aby okno główne wiedziało, że nie musi odświeżać tabeli
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
