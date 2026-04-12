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
            if (string.IsNullOrWhiteSpace(txtoffername.Text) || comboBox_category.SelectedValue == null)
            {
                MessageBox.Show("Proszę uzupełnić nazwę i rodzaj oferty.");
                return;
            }

            if (numericUpDown_price.Value <= 0)
            {
                MessageBox.Show("Cena musi być większa od 0 zł.", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Zapytanie definiujące strukturę dla Adaptera
                    string query = "SELECT * FROM OfertaCukierni WHERE 1=0"; // Pobieramy tylko schemat

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    // SqlCommandBuilder automatycznie wygeneruje polecenie INSERT
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "OfertaCukierni");

                    // Tworzenie nowego wiersza w pamięci RAM (Disconnected)
                    DataTable table = ds.Tables["OfertaCukierni"];
                    DataRow newRow = table.NewRow();

                    newRow["IdKategorii"] = comboBox_category.SelectedValue;
                    newRow["Nazwa"] = txtoffername.Text;
                    newRow["Opis"] = txtOpis.Text;
                    newRow["Cena"] = numericUpDown_price.Value;
                    newRow["Aktywne"] = 1;

                    table.Rows.Add(newRow);

                    // Synchronizacja zmian z bazą danych
                    adapter.Update(ds, "OfertaCukierni");

                    MessageBox.Show("Pomyślnie dodano nową ofertę!");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania: " + ex.Message);
            }
        }
    }
}
