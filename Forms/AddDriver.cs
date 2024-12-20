using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CB011911.CS;

namespace CB011911
{
    public partial class AddDriver : Form
    {
        public AddDriver()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ManageDrivers manageDrivers = new ManageDrivers();
            manageDrivers.Show();
            this.Hide();
        }

        private bool availability;
        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                availability = true;
            }
            else
            {
                availability = false;
            }

            Driver newDriver = new Driver(textBox1.Text, textBox2.Text, availability,textBox3.Text);
            DriverManager.add_driver(newDriver);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AddDriver_Load(object sender, EventArgs e)
        {

        }
    }
}
