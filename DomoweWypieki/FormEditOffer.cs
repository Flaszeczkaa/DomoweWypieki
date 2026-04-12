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
    public partial class FormEditOffer : Form
    {
        private int productId;
        private int originalCategoryId;
        private string originalName;
        private string originalDescription;
        private decimal originalPrice;

        private string connectionString = ConfigurationManager.ConnectionStrings["DomoweWypiekiConn"].ConnectionString;

        public FormEditOffer(int id, int catId, string name, string description, decimal price)
        {
            InitializeComponent();

            // dane początkowe
            this.productId = id;
            this.originalCategoryId = catId;
            this.originalName = name;
            this.originalDescription = description;
            this.originalPrice = price;

            LoadCategories();

            //dane
            txt_Name.Text = name;
            txt_Description.Text = description;
            nud_Price.Value = price;

            comboBox_category.SelectedValue = catId;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string currentName = txt_Name.Text.Trim();
            string currentDescription = txt_Description.Text.Trim();
            decimal currentPrice = nud_Price.Value;

            bool hasChanged = currentName != originalName ||
                              currentDescription != originalDescription ||
                              currentPrice != originalPrice;

            if (!hasChanged)
            {
                this.Close();
                return;
            }

            //WALIDACJA - Cena > 0 zgodnie z CHECK w SQL
            if (currentPrice <= 0)
            {
                MessageBox.Show("Cena musi być większa od zera!", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(currentName))
            {
                MessageBox.Show("Nazwa wypieku nie może być pusta!", "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // zapis zmian do bazy
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = "UPDATE OfertaCukierni SET Nazwa = @name, Opis = @desc, Cena = @price WHERE IdProduktu = @id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", currentName);
                        cmd.Parameters.AddWithValue("@desc", currentDescription);
                        cmd.Parameters.AddWithValue("@price", currentPrice);
                        cmd.Parameters.AddWithValue("@id", productId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Zmiany w ofercie zostały zapisane.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategories()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT IdKategorii, NazwaKategorii FROM Kategorie";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    comboBox_category.DataSource = dt;
                    comboBox_category.DisplayMember = "NazwaKategorii"; 
                    comboBox_category.ValueMember = "IdKategorii";  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania kategorii: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz anulować edycję? Wprowadzone zmiany nie zostaną zapisane.",
                "Anulowanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
