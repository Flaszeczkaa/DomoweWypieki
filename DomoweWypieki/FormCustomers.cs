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
    public partial class FormCustomers : Form
    {
        public FormCustomers()
        {
            InitializeComponent();
        }

        private void FormCustomers_Load(object sender, EventArgs e)
        {
            try
            {
                this.klienciTableAdapter.Fill(this.domoweWypiekiDataSet.Klienci);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd ładowania: " + ex.Message);
            }
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz zakończyć pracę i wrócić do menu?", "Powrót", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_add_customer_Click(object sender, EventArgs e)
        {
            FormAddClient addClientForm = new FormAddClient();
            addClientForm.ShowDialog();
            this.klienciTableAdapter.Fill(this.domoweWypiekiDataSet.Klienci);

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string searching = txt_search_user.Text.Trim();

            if (string.IsNullOrWhiteSpace(searching))
            {
                klienciBindingSource.RemoveFilter();
            }
            else
            {
                klienciBindingSource.Filter = string.Format("Imie LIKE '%{0}%' OR Nazwisko LIKE '%{0}%' OR Email LIKE '%{0}%'", searching);
            }
        }

        private void btn_delete_customer_Click(object sender, EventArgs e)
        {
            if (klienciBindingSource.Current != null)
            {
                DialogResult dialog = MessageBox.Show("Czy na pewno chcesz usunąć wybranego klienta?", "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        klienciBindingSource.RemoveCurrent();

                        this.klienciTableAdapter.Update(this.domoweWypiekiDataSet.Klienci);

                        MessageBox.Show("Klient został usunięty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nie można usunąć tego klienta! Prawdopodobnie są do niego przypisane zamówienia w systemie.", "Błąd usuwania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.klienciTableAdapter.Fill(this.domoweWypiekiDataSet.Klienci);
                    }
                }
            }
            else
            {
                MessageBox.Show("Wybierz klienta z listy, aby go usunąć.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgv_customers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRowView currentRow = (DataRowView)klienciBindingSource.Current;

                int id = (int)currentRow["IdKlienta"];
                string firstName = currentRow["Imie"].ToString();
                string lastName = currentRow["Nazwisko"].ToString();
                string phone = currentRow["Telefon"].ToString();
                string email = currentRow["Email"].ToString();

                FormEditClient editForm = new FormEditClient(id, firstName, lastName, phone, email);

                editForm.ShowDialog();

                this.klienciTableAdapter.Fill(this.domoweWypiekiDataSet.Klienci);
            }
        }

        private void dgv_customers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
