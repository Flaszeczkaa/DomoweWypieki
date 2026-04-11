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
        public FormEditClient(int id, string firstName, string lastName, string phone, string email)
        {
            InitializeComponent();
            this.CustomerId = id;
            this.txtFirstName.Text = firstName;
            this.txtLastName.Text = lastName;
            this.txtPhone.Text = phone;
            this.txtEmail.Text = email;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

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
