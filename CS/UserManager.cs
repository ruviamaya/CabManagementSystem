using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CB011911.CS
{
    internal class UserManager
    {
        private static Customer loggedInCustomer;
        private static Driver loggedInDriver;


        public static Customer LoggedInCustomer
        {
            get { return loggedInCustomer; }
            set { loggedInCustomer = value; }
        }

        public static Driver LoggedInDriver
        {
            get { return loggedInDriver; }
            set { loggedInDriver = value; }
        }



        public bool AuthenticateAdmin(string username, string password)
        {
             SqlConnection connection = new DBconnector().GetConnection();
             connection.Open();

             string query = "SELECT * FROM Admin WHERE A_Name = @username AND A_password = @password";
             SqlCommand command = new SqlCommand(query, connection);

             //adding parameter
             command.Parameters.AddWithValue("@username", username);
             command.Parameters.AddWithValue("@password", password);

             SqlDataReader reader = command.ExecuteReader();
             if (reader.HasRows)
             {
                 return true;
             }
             else
             {
                 return false;
             }
        }

        public bool AuthenticateCustomer(string username, string password)
        {
            SqlConnection connection = new DBconnector().GetConnection();
            connection.Open();

            string query = "SELECT * FROM Customer WHERE C_Name = @username AND C_password = @password";
            SqlCommand command = new SqlCommand(query, connection);

            //adding parameters
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                int CustomerID = reader.GetInt32(0);
                string name = reader.GetString(1);
                string contact = reader.GetString(2);
                LoggedInCustomer = new Customer(CustomerID, name, contact, password);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool AuthenticateDriver(string username, string password)
        {
            SqlConnection connection = new DBconnector().GetConnection();
            connection.Open();

            string query = "SELECT * FROM Driver WHERE D_Name = @username AND D_password = @password";
            SqlCommand command = new SqlCommand(query, connection);

            //adding parameters
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                int DriverID = reader.GetInt32(0);
                string name = reader.GetString(1);
                string contact = reader.GetString(2);
                bool availability = reader.GetBoolean(3);
                LoggedInDriver = new Driver(DriverID, name, contact, availability);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
