using CB011911.CS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB011911.Forms
{
    public partial class ViewMyTrips_Customer_ : Form
    {
        public ViewMyTrips_Customer_()
        {
            InitializeComponent();
            load();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            CustomerDashboard customerDashboard = new CustomerDashboard();
            customerDashboard.Show();
            this.Hide();
        }

        public void load()
        {
            try
            {
                Customer customer = UserManager.LoggedInCustomer;

                DataTable dataTable = Customer.ViewMyTrips(customer);
                // Display the record in the DataGridView
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }

        }
    }
}
