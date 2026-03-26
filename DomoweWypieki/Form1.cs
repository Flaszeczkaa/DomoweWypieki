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

        private void btn_Addons_Click(object sender, EventArgs e)
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
    }
}
