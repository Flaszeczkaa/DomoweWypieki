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
    public partial class FormConfectioneryOffer : Form
    {
        public FormConfectioneryOffer()
        {
            InitializeComponent();
        }

        private void dgv_offer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_add_cake_Click(object sender, EventArgs e)
        {
            FormAddOffer formAddOffer = new FormAddOffer();
            this.Hide();
            formAddOffer.ShowDialog();
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
    }
}
