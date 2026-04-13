using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomoweWypieki
{
    public partial class FormAddOffer : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DomoweWypiekiConn"].ConnectionString;

        public FormAddOffer()
        {
            InitializeComponent();
            this.Load += FormAddOffer_Load;
            comboBox_category.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void FormAddOffer_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Ładujemy słownik kategorii do ComboBoxa
                    string query = "SELECT IdKategorii, NazwaKategorii FROM Kategorie";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataSet ds = new DataSet();

                    adapter.Fill(ds, "Kategorie");

                    comboBox_category.DataSource = ds.Tables["Kategorie"];
                    comboBox_category.DisplayMember = "NazwaKategorii";
                    comboBox_category.ValueMember = "IdKategorii";
                    comboBox_category.SelectedIndex = -1; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania kategorii: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult wynik = MessageBox.Show("Czy na pewno chcesz zakończyć pracę i wrócić do menu?", "Powrót", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (wynik == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Walidacja
            if (string.IsNullOrWhiteSpace(txtoffername.Text) || comboBox_category.SelectedValue == null)
            {
                MessageBox.Show("Proszę uzupełnić nazwę i rodzaj oferty.");
                return;
            }

            // Cena musi być > 0
            if (numericUpDown_price.Value <= 0)
            {
                MessageBox.Show("Cena musi być większa od 0 zł.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DomoweWypiekiDataSetTableAdapters.OfertaCukierniTableAdapter adapter = new DomoweWypiekiDataSetTableAdapters.OfertaCukierniTableAdapter();

                int idKategorii = (int)comboBox_category.SelectedValue;
                string nazwa = txtoffername.Text.Trim();
                string opis = txtOpis.Text.Trim();
                decimal cena = numericUpDown_price.Value;
                bool aktywne = true; // Zawsze true dla nowych wypieków

                adapter.Insert(idKategorii, nazwa, opis, cena, aktywne);

                MessageBox.Show("Pomyślnie dodano nową ofertę!");
                this.DialogResult = DialogResult.OK; // Daje sygnał oknie głównemu, żeby odświeżyło tabelę
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania: " + ex.Message);
            }
        }


    }
}