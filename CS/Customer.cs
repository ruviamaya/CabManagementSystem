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
    internal class Customer : User
    {
        private int customer_ID;
        private string password;

        // Properties
        public int Customer_ID
        {
            get { return customer_ID; }
            set { customer_ID = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        // Constructor
        public Customer(int id, string name, string contact,string password) : base(name, contact)
        {
            customer_ID = id;
            Name = name;
            Contact = contact;
            this.password = password;
        }

        //overloaded constructors
        public Customer(string name, string contact, string password) : base(name, contact)
        {
            Name = name;
            Contact = contact;
            this.password = password;
        }

        public Customer(int id, string name, string contact) : base(name, contact)
        {
            this.customer_ID = id;
            Name = name;
            Contact = contact;
        }



        //View my (current customers) trips
        public static DataTable ViewMyTrips(Customer customer)
        {
            SqlConnection connection = new DBconnector().GetConnection();
            DataTable dataTable = new DataTable();
            
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Orders WHERE Customer_Id = @id", connection);
                
                //adding parameters
                command.Parameters.AddWithValue("@id", customer.Customer_ID);
                
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
