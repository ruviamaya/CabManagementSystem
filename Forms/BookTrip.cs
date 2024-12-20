using CB011911.CS;
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

namespace CB011911
{
    public partial class BookTrip : Form
    {
        public BookTrip()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            CustomerDashboard customerDashboard = new CustomerDashboard();
            customerDashboard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = VehicleManager.viewAvailableVehicles();

            // Display the record in the DataGridView
            dataGridView1.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dataTable = DriverManager.ViewAvailableDrivers();

            // Display the record in the DataGridView
            dataGridView1.DataSource = dataTable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string PickUpLocation = textBox1.Text;
            string DropOffLocation = textBox2.Text;
            DateTime dateTime = dateTimePicker1.Value;

            int VehicleId = Convert.ToInt32(textBox3.Text);
            int DriverId = Convert.ToInt32(textBox4.Text);
            int CustomerId = UserManager.LoggedInCustomer.Customer_ID;

            int V_rows = VehicleManager.check_availability(VehicleId);
            int D_rows = DriverManager.check_availability(DriverId);
            if (V_rows == 0)
            {
                MessageBox.Show("This Vehicle is not available. Please choose another vehicle.");
            }
            else if (D_rows == 0)
            {
                MessageBox.Show("This Driver is not available. Please choose another driver.");
            }
            else
            {
                Order order = new Order(CustomerId, DriverId, VehicleId, dateTime, PickUpLocation, DropOffLocation);
                order.SaveOrder(order);

                DriverManager.Update_DriverAvailability(DriverId, false);
                VehicleManager.Update_VehicleAvailability(VehicleId, false);
            }
        }
    }
}
