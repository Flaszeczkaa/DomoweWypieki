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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Orders_Click(object sender, EventArgs e)
        {
            FormOrders ordersForm = new FormOrders();

            ordersForm.StartPosition = FormStartPosition.Manual;

            ordersForm.Location = this.Location;

            this.Hide();
            ordersForm.ShowDialog();

            this.Location = ordersForm.Location;

            this.Show();
        }

        private void btn_Customers_Click(object sender, EventArgs e)
        {
            FormCustomers customersForm = new FormCustomers();

            customersForm.StartPosition = FormStartPosition.Manual;

            customersForm.Location = this.Location;

            this.Hide();
            customersForm.ShowDialog();

            this.Location = customersForm.Location;

            this.Show();
        }
    }
}
