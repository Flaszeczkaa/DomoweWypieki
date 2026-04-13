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
    public partial class FormAddOrder_Step2 : Form
    {
        private DataTable cartTable; // Odbiera koszyk z Kroku 1
        private decimal baseTotalSum = 0;

        private string connectionString = Properties.Settings.Default.DomoweWypiekiConnectionString;

        public FormAddOrder_Step2(DataTable providedCart)
        {
            InitializeComponent();
            this.cartTable = providedCart;

            // Ustawienia pól kwoty
            txb_FinalPrice.ReadOnly = true;
            txb_FinalPrice.BackColor = SystemColors.Window;

            // Ręczne wymuszenie podpięcia zdarzeń (gwarancja działania)
            this.Load += new System.EventHandler(this.FormAddOrder_Step2_Load);
            this.btn_AddOrder.Click += new System.EventHandler(this.btn_AddOrder_Click);
            this.btn_CancelOrder.Click += new System.EventHandler(this.btn_CancelOrder_Click);
            this.nud_Discount.ValueChanged += new System.EventHandler(this.nud_Discount_ValueChanged);
        }

        private void FormAddOrder_Step2_Load(object sender, EventArgs e)
        {
            try
            {
                // Ładowanie danych z bazy
                this.klienciTableAdapter1.Fill(this.domoweWypiekiDataSet1.Klienci);
                this.rodzajePlatnosciTableAdapter1.Fill(this.domoweWypiekiDataSet1.RodzajePlatnosci);

                // "Imię + Nazwisko" W KODZIE (Pełne Imię)
                if (!this.domoweWypiekiDataSet1.Klienci.Columns.Contains("PelneImie"))
                {
                    this.domoweWypiekiDataSet1.Klienci.Columns.Add("PelneImie", typeof(string), "Imie + ' ' + Nazwisko");
                }

                cb_Customers.DataSource = this.domoweWypiekiDataSet1.Klienci;
                cb_Customers.DisplayMember = "PelneImie";
                cb_Customers.ValueMember = "IdKlienta";

                cb_PaymentsMethod.DataSource = this.domoweWypiekiDataSet1.RodzajePlatnosci;
                cb_PaymentsMethod.DisplayMember = "NazwaPlatnosci";
                cb_PaymentsMethod.ValueMember = "IdRodzajuPlatnosci";

                CalculateCartSum();
                CalculateFinalPrice();

                // Ustawienie dat
                dtp_OrderDate.Value = DateTime.Now;
                dtp_RealizationDate.Value = DateTime.Now.AddDays(2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania danych: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateCartSum()
        {
            baseTotalSum = 0;
            if (cartTable != null)
            {
                foreach (DataRow row in cartTable.Rows)
                {
                    baseTotalSum += Convert.ToDecimal(row["Wartosc"]);
                }
            }
        }

        private void CalculateFinalPrice()
        {
            // Liczy rabat
            decimal discountPercentage = nud_Discount.Value / 100m;
            decimal priceAfterDiscount = baseTotalSum - (baseTotalSum * discountPercentage);

            if (priceAfterDiscount < 0) priceAfterDiscount = 0;

            txb_FinalPrice.Text = priceAfterDiscount.ToString("C"); // Format walutowy 
            txb_FinalPrice.Tag = priceAfterDiscount; 
        }

        private void nud_Discount_ValueChanged(object sender, EventArgs e)
        {
            CalculateFinalPrice();
        }

        private void btn_AddOrder_Click(object sender, EventArgs e)
        {
            //Walidacja - czy wybrano klienta i metodę płatności
            if (cb_Customers.SelectedValue == null)
            {
                MessageBox.Show("Wybierz klienta!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cb_PaymentsMethod.SelectedValue == null)
            {
                MessageBox.Show("Wybierz metodę płatności!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Walidacja - Data realizacji musi być późniejsza lub równa dacie złożenia
            if (dtp_RealizationDate.Value.Date < dtp_OrderDate.Value.Date)
            {
                MessageBox.Show("Data realizacji nie może być wcześniejsza niż data złożenia zamówienia!",
                                "Błąd daty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            //Walidacja - sprawdzenie czy data realizacji nie jest z przeszłości
            if (dtp_RealizationDate.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Data realizacji nie może być datą z przeszłości!",
                                "Błąd daty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Zapisywanie danych do bazy 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction("SaveOrder");

                try
                {
                    string orderSql = @"INSERT INTO dbo.Zamowienia (IdKlienta, IdStatusu, DataZlozenia, DataRealizacji, RabatProcent) 
                                        OUTPUT INSERTED.IdZamowienia 
                                        VALUES (@IdK, @IdS, @DataZ, @DataR, @Rabat)";

                    int newOrderId;
                    using (SqlCommand cmd = new SqlCommand(orderSql, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@IdK", cb_Customers.SelectedValue);
                        cmd.Parameters.AddWithValue("@IdS", 1); 
                        cmd.Parameters.AddWithValue("@DataZ", dtp_OrderDate.Value);
                        cmd.Parameters.AddWithValue("@DataR", dtp_RealizationDate.Value);
                        cmd.Parameters.AddWithValue("@Rabat", nud_Discount.Value / 100m);
                        newOrderId = (int)cmd.ExecuteScalar();
                    }

                    //Pozycje z koszyka
                    string itemSql = @"INSERT INTO dbo.PozycjeZamowienia (IdZamowienia, IdProduktu, Ilosc, CenaBazowa, ProsbaKlienta, SumaDoplat) 
                                       VALUES (@IdZ, @IdP, @Il, @Cena, @Prosba, @Doplata)";

                    foreach (DataRow row in cartTable.Rows)
                    {
                        using (SqlCommand cmdItem = new SqlCommand(itemSql, conn, transaction))
                        {
                            cmdItem.Parameters.AddWithValue("@IdZ", newOrderId);
                            cmdItem.Parameters.AddWithValue("@IdP", row["IdProduktu"]);
                            cmdItem.Parameters.AddWithValue("@Il", row["Ilosc"]);
                            cmdItem.Parameters.AddWithValue("@Cena", row["CenaBazowa"]);
                            cmdItem.Parameters.AddWithValue("@Doplata", row["SumaDoplat"]);

                            object wish = row["ProsbaKlienta"];
                            cmdItem.Parameters.AddWithValue("@Prosba", string.IsNullOrEmpty(wish.ToString()) ? DBNull.Value : wish);

                            cmdItem.ExecuteNonQuery();
                        }
                    }

                    //Płatność
                    string paymentSql = @"INSERT INTO dbo.Platnosci (IdZamowienia, IdRodzajuPlatnosci, DataPlatnosci, Kwota) 
                                          VALUES (@IdZ, @IdRP, GETDATE(), @Kwota)";

                    using (SqlCommand cmdPay = new SqlCommand(paymentSql, conn, transaction))
                    {
                        cmdPay.Parameters.AddWithValue("@IdZ", newOrderId);
                        cmdPay.Parameters.AddWithValue("@IdRP", cb_PaymentsMethod.SelectedValue);
                        cmdPay.Parameters.AddWithValue("@Kwota", txb_FinalPrice.Tag);
                        cmdPay.ExecuteNonQuery();
                    }

                    transaction.Commit(); // Zatwierdzenie transakcji po pomyślnym wykonaniu wszystkich operacji
                    MessageBox.Show("Zamówienie nr " + newOrderId + " zapisane pomyślnie!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Błąd zapisu: " + ex.Message, "Błąd krytyczny", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_CancelOrder_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz anulować całe zamówienie i wrócić do menu głównego?", "Anulowanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }
    }
}