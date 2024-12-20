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
    public partial class UpdateVehicle : Form
    {
        private bool availability;
        public UpdateVehicle()
        {
            InitializeComponent();
            VehicleManager.view_vehicles(dataGridView1);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ManageVehicle manageVehicle = new ManageVehicle();
            manageVehicle.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VehicleManager.view_vehicles(dataGridView1);
        }

        
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

            Vehicle newVehicle = new Vehicle(id,textBox2.Text,textBox3.Text,availability);
            VehicleManager.update_vehicle(newVehicle);
            VehicleManager.view_vehicles(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            VehicleManager.delete_vehicle(id);
            VehicleManager.view_vehicles(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            DataTable dataTable = VehicleManager.viewVehicleByID(id);

            // Display the record in the DataGridView
            dataGridView1.DataSource = dataTable;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dataTable = VehicleManager.viewAvailableVehicles();

            // Display the record in the DataGridView
            dataGridView1.DataSource = dataTable;
        }
    }
}
