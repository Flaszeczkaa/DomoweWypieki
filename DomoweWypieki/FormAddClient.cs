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
            string name = txtFirstName.Text.Trim();
            string surname = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone_number = txtPhone.Text.Trim();

            //Walidacja danych
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(phone_number))
            {
                MessageBox.Show("Pola 'Imię', 'Nazwisko' i 'Numer Telefonu' nie mogą być puste!", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(phone_number, @"^\d{9}$"))
            {
                MessageBox.Show("Numer telefonu musi składać się dokładnie z 9 cyfr!", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                if (!email.Contains("@"))
                {
                    MessageBox.Show("Podaj poprawny adres e-mail (musi zawierać znak '@').", "Błąd zapisu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            //Zapis do bazy danych
            try
            {
                DomoweWypiekiDataSetTableAdapters.KlienciTableAdapter clientsAdapter = new DomoweWypiekiDataSetTableAdapters.KlienciTableAdapter();

                clientsAdapter.Insert(name, surname, phone_number, email);

                MessageBox.Show("Użytkownik został pomyślnie dodany do bazy!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas komunikacji z bazą: " + ex.Message, "Krytyczny błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFirstName.Text) ||
            !string.IsNullOrWhiteSpace(txtLastName.Text) ||
            !string.IsNullOrWhiteSpace(txtPhone.Text) ||
            !string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    //Jeśli pola nie puste, pytamy o potwierdzenie
                    DialogResult result = MessageBox.Show("Czy na pewno chcesz zakończyć pracę i wrócić do menu?", "Powrót", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                else
                {
                    //Jeśli pola puste, zamykamy bez pytania
                    this.Close();
                }
            }
    }
}
