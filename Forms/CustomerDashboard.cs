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
    public partial class CustomerDashboard : Form
    {
        public CustomerDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookTrip bookTrip = new();
            bookTrip.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewMyTrips_Customer_ viewTrips = new ViewMyTrips_Customer_();
            viewTrips.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditDetails editDetails = new EditDetails();
            editDetails.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
