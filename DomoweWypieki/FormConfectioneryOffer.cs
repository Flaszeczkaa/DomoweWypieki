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
    public partial class FormConfectioneryOffer : Form
    {
        public FormConfectioneryOffer()
        {
            InitializeComponent();
            // Malowanie na czerwono wycofanych produktów 
            this.dgv_offer.CellFormatting += dgv_offer_CellFormatting;
        }

        private void dgv_offer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Pobieramy dane z zaznaczonego wiersza w pamięci RAM
                DataRowView currentRow = (DataRowView)ofertaCukierniBindingSource.Current;

                int id = (int)currentRow["IdProduktu"];
                int idKategorii = (int)currentRow["IdKategorii"];
                string nazwa = currentRow["Nazwa"].ToString();
                string opis = currentRow["Opis"].ToString();
                decimal cena = (decimal)currentRow["Cena"];

                // Przekazujemy dane do okna edycji
                FormEditOffer editForm = new FormEditOffer(id, idKategorii, nazwa, opis, cena);

                editForm.StartPosition = FormStartPosition.Manual;
                editForm.Location = this.Location;

                // Jeśli w oknie edycji zapisano to odświeżamy tabelę
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    this.ofertaCukierniTableAdapter.Fill(this.domoweWypiekiDataSet.OfertaCukierni);
                }
            }
        }

        private void btn_add_cake_Click(object sender, EventArgs e)
        {
            FormAddOffer formAddOffer = new FormAddOffer();
            this.Hide();
            // Jeśli dodano nowe ciasto odświeżamy tabelę
            if (formAddOffer.ShowDialog() == DialogResult.OK)
            {
                this.ofertaCukierniTableAdapter.Fill(this.domoweWypiekiDataSet.OfertaCukierni);
            }
            this.Show();
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            DialogResult wynik = MessageBox.Show("Czy na pewno chcesz zakończyć pracę i wrócić do menu?", "Powrót", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (wynik == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FormConfectioneryOffer_Load(object sender, EventArgs e)
        {
            // Ładowanie danych z bazy do wirtualnego DataSetu 
            this.ofertaCukierniTableAdapter.Fill(this.domoweWypiekiDataSet.OfertaCukierni);
        }

        private void dgv_offer_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void btn_withdraw_from_sale_Click(object sender, EventArgs e)
        {
            // REGUŁA BIZNESOWA: Soft Delete 
            if (ofertaCukierniBindingSource.Current != null)
            {
                var selectedRow = (DomoweWypiekiDataSet.OfertaCukierniRow)((DataRowView)ofertaCukierniBindingSource.Current).Row;

                // Zabezpieczenie: czy już jest wycofane?
                if (!selectedRow.Aktywne)
                {
                    MessageBox.Show($"Ciasto '{selectedRow.Nazwa}' jest już wycofane z oferty.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string nazwaCiasta = selectedRow.Nazwa;

                DialogResult result = MessageBox.Show($"Czy na pewno chcesz wycofać '{nazwaCiasta}' z oferty?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        selectedRow.Aktywne = false;

                        ofertaCukierniBindingSource.EndEdit();

                        // Adapter wysyła komendę UPDATE do bazy SQL
                        this.ofertaCukierniTableAdapter.Update(this.domoweWypiekiDataSet.OfertaCukierni);

                        MessageBox.Show("Produkt został wycofany z oferty.", "Sukces");
                        dgv_offer.Refresh(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd podczas aktualizacji: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć ciasto na liście.");
            }
        }

        //Automatyczne malowanie na czerwono wycofanych produktów
        private void dgv_offer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgv_offer.Rows.Count) return;

            var rowView = dgv_offer.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (rowView != null)
            {
                var row = rowView.Row as DomoweWypiekiDataSet.OfertaCukierniRow;

                if (row != null && !row.Aktywne)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(dgv_offer.Font, FontStyle.Bold);
                }
            }
        }
    }
}