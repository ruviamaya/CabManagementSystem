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
    public partial class UpdateDriver : Form
    {
        public UpdateDriver()
        {
            InitializeComponent();
            DriverManager.view_drivers(dataGridView1);
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

            int id = int.Parse(textBox1.Text);

            Driver newDriver = new Driver(id, textBox2.Text, textBox3.Text, availability);
            DriverManager.update_driver(newDriver);
            DriverManager.view_drivers(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            DriverManager.delete_driver(id);
            DriverManager.view_drivers(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            DataTable dataTable = DriverManager.ViewDriverByID(id);

            // Display the record in the DataGridView
            dataGridView1.DataSource = dataTable;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DriverManager.view_drivers(dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dataTable = DriverManager.ViewAvailableDrivers();

            // Display the record in the DataGridView
            dataGridView1.DataSource = dataTable;
        }
    }
}
