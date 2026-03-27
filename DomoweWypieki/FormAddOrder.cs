using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DomoweWypieki
{
    public partial class FormAddOrder : Form
    {
        private string connectionString = @"Data Source=localhost;Initial Catalog=DomoweWypieki;Integrated Security=True";

        private DataSet dsAddOrder = new DataSet();

        public FormAddOrder()
        {
            InitializeComponent();
        }
        
    }
}
