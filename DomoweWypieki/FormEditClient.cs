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
        private int CustomerId;
        private string originalFirstName;
        private string originalLastName;
        private string originalPhone;
        private string originalEmail;
        public FormEditClient(int id, string firstName, string lastName, string phone, string email)
        {
            InitializeComponent();
            this.CustomerId = id;

            // Zapamiętujemy stan początkowy
            this.originalFirstName = firstName != null ? firstName.Trim() : "";
            this.originalLastName = lastName != null ? lastName.Trim() : "";
            this.originalPhone = phone != null ? phone.Trim() : "";
            this.originalEmail = email != null ? email.Trim() : "";

            // Wpisujemy wyczyszczone dane do TextBoxów
            this.txtFirstName.Text = this.originalFirstName;
            this.txtLastName.Text = this.originalLastName;
            this.txtPhone.Text = this.originalPhone;
            this.txtEmail.Text = this.originalEmail;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Pobieramy to co wpisał user
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            //Sprawdzamy czy cokolwiek się zmieniło - jeśli nie to zamykamy okno bez aktualizacji bazy
            bool hasChanged = firstName != originalFirstName ||
                              lastName != originalLastName ||
                              phone != originalPhone ||
                              email != originalEmail;

            if (!hasChanged)
            {
                this.Close();
                return;
            }

            //Walidacja danych
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Pola 'Imię', 'Nazwisko' i 'Numer Telefonu' nie mogą być puste!", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^\d{9}$"))
            {
                MessageBox.Show("Numer telefonu musi składać się dokładnie z 9 cyfr!", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(email) && !email.Contains("@"))
            {
                MessageBox.Show("Podaj poprawny adres e-mail (musi zawierać znak '@').", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Update danych w bazie
            try
            {
                DomoweWypiekiDataSetTableAdapters.KlienciTableAdapter adapter = new DomoweWypiekiDataSetTableAdapters.KlienciTableAdapter();

                adapter.UpdateClientQuery(firstName, lastName, phone, email, CustomerId);

                MessageBox.Show("Dane klienta zaktualizowane pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas aktualizacji danych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz zakończyć pracę i wrócić do menu?", "Powrót", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
