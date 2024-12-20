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

namespace CB011911
{
    public partial class ViewTrips : Form
    {
        public ViewTrips()
        {
            InitializeComponent();
            Admin.view_order(dataGridView1);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Hide();
        }
    }
}
