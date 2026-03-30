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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult wynik = MessageBox.Show("Czy na pewno chcesz wyjść?", "Wyjście", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (wynik == DialogResult.Yes)
            {
                Application.Exit();
            }
                
        }

        private void btn_CakesOffer_Click(object sender, EventArgs e)
        {
            FormConfectioneryOffer formOffer = new FormConfectioneryOffer();
            this.Hide();
            formOffer.ShowDialog();
            this.Show();
        }

        private void btn_Customers_Click(object sender, EventArgs e)
        {
            FormCustomers formCustomers = new FormCustomers();
            this.Hide();
            formCustomers.ShowDialog();
            this.Show();
        }

        private void btn_AddOrder_Click(object sender, EventArgs e)
        {
            FormAddOrder_Step1 formAddOrder = new FormAddOrder_Step1();
            this.Hide();
            formAddOrder.ShowDialog();
            this.Show();
        }

        private void btn_ViewingOrders_Click(object sender, EventArgs e)
        {
            FormOrders formOrders = new FormOrders();
            this.Hide();
            formOrders.ShowDialog();
            this.Show();
        }

       
    }
}
