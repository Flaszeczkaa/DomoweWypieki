using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomoweWypieki
{
    public partial class FormAddOrder_Step1 : Form
    {
        private DataTable cartTable;

        private const decimal COST_DECORATION = 30.00m;
        private const decimal COST_TOPPER = 25.00m;
        private const decimal COST_PREMIUM = 40.00m;

        public FormAddOrder_Step1()
        {
            InitializeComponent();
            PrepareCart();
        }

        private void PrepareCart()
        {
            cartTable = new DataTable();
            // Kolumny widoczne na interfejsie zostawiamy po polsku
            cartTable.Columns.Add("IdProduktu", typeof(int));
            cartTable.Columns.Add("NazwaProduktu", typeof(string));
            cartTable.Columns.Add("Ilosc", typeof(int));
            cartTable.Columns.Add("CenaBazowa", typeof(decimal));
            cartTable.Columns.Add("SumaDoplat", typeof(decimal));
            cartTable.Columns.Add("ProsbaKlienta", typeof(string));
            cartTable.Columns.Add("Wartosc", typeof(decimal), "(CenaBazowa + SumaDoplat) * Ilosc");

            dgv_Cart.DataSource = cartTable;
            dgv_Cart.Columns["IdProduktu"].Visible = false;
            dgv_Cart.Columns["Wartosc"].DefaultCellStyle.Format = "c";
            dgv_Cart.Columns["CenaBazowa"].DefaultCellStyle.Format = "c";
            dgv_Cart.Columns["SumaDoplat"].DefaultCellStyle.Format = "c";

            dgv_Cart.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8);
            dgv_Cart.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            dgv_Cart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void FormAddOrder_Step1_Load(object sender, EventArgs e)
        {
            if (this.domoweWypiekiDataSet1 != null)
            {
                this.kategorieTableAdapter1.Fill(this.domoweWypiekiDataSet1.Kategorie);
                this.ofertaCukierniTableAdapter1.Fill(this.domoweWypiekiDataSet1.OfertaCukierni);

                cb_category.SelectedIndexChanged -= cb_category_SelectedIndexChanged;
                btn_delete_from_cart.Click -= btn_delete_from_cart_Click;

                cb_category.DataSource = this.domoweWypiekiDataSet1.Kategorie;
                cb_category.DisplayMember = "NazwaKategorii";
                cb_category.ValueMember = "IdKategorii";

                cb_category.SelectedIndexChanged += cb_category_SelectedIndexChanged;
                btn_delete_from_cart.Click += btn_delete_from_cart_Click;
            }
        }

        private void cb_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_category.SelectedValue != null && int.TryParse(cb_category.SelectedValue.ToString(), out int categoryId))
            {
                DataView dvProducts = new DataView(this.domoweWypiekiDataSet1.OfertaCukierni);
                dvProducts.RowFilter = $"IdKategorii = {categoryId} AND (Aktywne = 1 OR Aktywne = True)";

                cb_Cakes.DataSource = dvProducts;
                cb_Cakes.DisplayMember = "Nazwa";
                cb_Cakes.ValueMember = "IdProduktu";

                if (categoryId == 2)
                {
                    gb_PremiumAdds.Enabled = true;
                }
                else
                {
                    gb_PremiumAdds.Enabled = false;
                    ClearAddons();
                }
            }
        }

        private void ClearAddons()
        {
            chbDecorationPremium.Checked = false;
            chbTopperPremium.Checked = false;
            chbTastePremium.Checked = false;
            txt_wish.Clear();
        }

        private void btn_AddToCart_Click(object sender, EventArgs e)
        {
            if (cb_Cakes.SelectedValue == null || cb_Cakes.SelectedItem == null)
            {
                MessageBox.Show("Wybierz produkt z listy!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nup_Cakes.Value <= 0)
            {
                MessageBox.Show("Ilość musi być większa od zera!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView selectedRow = (DataRowView)cb_Cakes.SelectedItem;

            int productId = Convert.ToInt32(selectedRow["IdProduktu"]);
            string productName = selectedRow["Nazwa"].ToString();
            decimal basePrice = Convert.ToDecimal(selectedRow["Cena"]);
            int quantity = (int)nup_Cakes.Value;

            decimal addonPrice = 0;
            string addonsAndWish = txt_wish.Text.Trim();
            string selectedOptions = "";

            if (gb_PremiumAdds.Enabled)
            {
                if (chbDecorationPremium.Checked) { addonPrice += COST_DECORATION; selectedOptions += "Dekoracja, "; }
                if (chbTopperPremium.Checked) { addonPrice += COST_TOPPER; selectedOptions += "Topper, "; }
                if (chbTastePremium.Checked) { addonPrice += COST_PREMIUM; selectedOptions += "Smak Premium, "; }

                if (!string.IsNullOrEmpty(selectedOptions))
                {
                    addonsAndWish = $"[{selectedOptions.TrimEnd(',', ' ')}] {addonsAndWish}";
                }
            }

            cartTable.Rows.Add(productId, productName, quantity, basePrice, addonPrice, addonsAndWish);

            nup_Cakes.Value = 1;
            ClearAddons();
        }

        private void btn_delete_from_cart_Click(object sender, EventArgs e)
        {
            if (dgv_Cart.CurrentRow != null && !dgv_Cart.CurrentRow.IsNewRow)
            {
                dgv_Cart.Rows.Remove(dgv_Cart.CurrentRow);
            }
            else
            {
                MessageBox.Show("Zaznacz produkt w tabeli, który chcesz usunąć.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_NextStep_Click(object sender, EventArgs e)
        {
            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Koszyk jest pusty! Dodaj produkty do zamówienia.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FormAddOrder_Step2 formCheckout = new FormAddOrder_Step2(cartTable);
            this.Hide();

            DialogResult result = formCheckout.ShowDialog();

            if (result == DialogResult.OK || result == DialogResult.Abort)
            {
                this.Close();
            }
            else
            {
                this.Show();
            }
        }

        private void btn_CancelOrder_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz zakończyć pracę i wrócić do menu?", "Powrót", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}