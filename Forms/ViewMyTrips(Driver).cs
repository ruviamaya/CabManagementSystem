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
    public partial class ViewMyTrips_Driver_ : Form
    {
        public ViewMyTrips_Driver_()
        {
            InitializeComponent();
            load();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DriverDashboard driverDashboard = new DriverDashboard();
            driverDashboard.Show();
            this.Hide();
        }

        public void load()
        {
            try
            {
                Driver driver = UserManager.LoggedInDriver;

                DataTable dataTable = Driver.ViewMyTrips(driver);
                // Display the record in the DataGridView
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
