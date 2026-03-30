using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DomoweWypieki
{
    public partial class FormAddOrder_Step1 : Form
    {
        private string connectionString = @"Data Source=localhost;Initial Catalog=DomoweWypieki;Integrated Security=True";

        private DataSet dsAddOrder = new DataSet();

        public FormAddOrder_Step1()
        {
            InitializeComponent();
        }

        private void btn_CancelOrder_Click(object sender, EventArgs e)
        {
            DialogResult wynik = MessageBox.Show("Czy na pewno chcesz zakończyć pracę i wrócić do menu?", "Powrót", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (wynik == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
