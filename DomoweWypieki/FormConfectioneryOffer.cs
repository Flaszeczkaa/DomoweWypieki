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
            this.dgv_offer.CellFormatting += dgv_offer_CellFormatting;
        }

        private void dgv_offer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_add_cake_Click(object sender, EventArgs e)
        {
            FormAddOffer formAddOffer = new FormAddOffer();
            this.Hide();
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
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'domoweWypiekiDataSet.OfertaCukierni' . Możesz go przenieść lub usunąć.
            this.ofertaCukierniTableAdapter.Fill(this.domoweWypiekiDataSet.OfertaCukierni);

        }

        private void dgv_offer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_withdraw_from_sale_Click(object sender, EventArgs e)
        {
            // 1. Sprawdzamy, czy zaznaczono wiersz w BindingSource
            if (ofertaCukierniBindingSource.Current != null)
            {
                // 2. Pobieramy aktualny wiersz jako obiekt Twojego DataSetu
                // Rzutujemy na konkretny typ wiersza wygenerowany przez Visual Studio
                var selectedRow = (DomoweWypiekiDataSet.OfertaCukierniRow)((DataRowView)ofertaCukierniBindingSource.Current).Row;

                if (!selectedRow.Aktywne)
                {
                    MessageBox.Show($"Ciasto '{selectedRow.Nazwa}' jest już wycofane z oferty.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string nazwaCiasta = selectedRow.Nazwa;

                // 3. Potwierdzenie operacji
                DialogResult result = MessageBox.Show(
                    $"Czy na pewno chcesz wycofać '{nazwaCiasta}' z oferty?",
                    "Potwierdzenie",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // 4. Zmieniamy wartość kolumny Aktywne na false (0 w bazie)
                        selectedRow.Aktywne = false;

                        // 5. Kończymy edycję w BindingSource, aby zatwierdzić zmiany w DataSet
                        ofertaCukierniBindingSource.EndEdit();

                        // 6. Przesyłamy zmiany z DataSetu do fizycznej bazy danych
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

        private void dgv_offer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Sprawdzamy czy to nie jest nagłówek i czy wiersz zawiera dane
            if (e.RowIndex < 0 || e.RowIndex >= dgv_offer.Rows.Count) return;

            // Pobieramy wiersz danych powiązany z tym rzędem w DataGridView
            var rowView = dgv_offer.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (rowView != null)
            {
                var row = rowView.Row as DomoweWypiekiDataSet.OfertaCukierniRow;

                // Jeśli flaga Aktywne to false (0), zmień kolor czcionki całego wiersza
                if (row != null && !row.Aktywne)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    // Opcjonalnie można zmienić też styl czcionki na przekreślenie lub pogrubienie
                    e.CellStyle.Font = new Font(dgv_offer.Font, FontStyle.Bold);
                }
            }
        }
    }
}
