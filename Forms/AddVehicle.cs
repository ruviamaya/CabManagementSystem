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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace CB011911
{
    public partial class AddVehicle : Form
    {
        public AddVehicle()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ManageVehicle manageVehicle = new ManageVehicle();
            manageVehicle.Show();
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

            Vehicle newVehicle = new Vehicle(textBox1.Text, textBox2.Text, availability);
            VehicleManager.add_vehicle(newVehicle);
        }
    }
}
