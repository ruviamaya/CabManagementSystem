using CB011911.CS;
using CB011911.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CB011911
{
    public partial class DriverDashboard : Form
    {
        public DriverDashboard()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewMyTrips_Driver_ viewTrips = new ViewMyTrips_Driver_();
            viewTrips.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int driver_id = UserManager.LoggedInDriver.DriverID;
            if (radioButton1.Checked)
            {
                DriverManager.Update_DriverAvailability(driver_id, true);
                MessageBox.Show("Availability updated to available");
            }
            else
            {
                DriverManager.Update_DriverAvailability(driver_id, false);
                MessageBox.Show("Availability updated to unavailable");
            }
        }
    }
}
