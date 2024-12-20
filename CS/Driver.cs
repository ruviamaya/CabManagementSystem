using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB011911.CS
{
    internal class Driver : User
    {
        private int driver_ID;
        private bool availability;
        private string password;

        // Properties
        public int DriverID
        {
            get { return driver_ID; }
            set { driver_ID = value; }
        }

        public bool Availability
        {
            get { return availability; }
            set { availability = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        // Constructor
        public Driver(string name, string contact, bool availability, string password) : base(name, contact)
        {
            Name = name;
            Contact = contact;
            this.availability = availability;
            this.password = password;
        }

        //overloaded constructor
        public Driver(int driver_ID, string name, string contact, bool availability) : base(name, contact)
        {
            this.driver_ID = driver_ID;
            this.availability = availability;
            Name = name;
            Contact = contact;
        }


        //View my (current driver) trips
        public static DataTable ViewMyTrips(Driver driver)
        {
            SqlConnection connection = new DBconnector().GetConnection();
            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Orders WHERE Driver_Id = @id", connection);

                //adding parameters
                command.Parameters.AddWithValue("@id", driver.driver_ID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }
    }
}
