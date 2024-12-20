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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CB011911
{
    public partial class EditDetails : Form
    {
        public EditDetails()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            CustomerDashboard customerDashboard = new CustomerDashboard();
            customerDashboard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = UserManager.LoggedInCustomer.Customer_ID;
            Customer newCustomer = new Customer(id, textBox1.Text, textBox2.Text);
            CustomerManager.update_customerDetails(newCustomer);
        }
    }
}
