using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB011911.CS
{
    internal class CustomerManager
    {
        public static void add_customer(Customer c)
        {
            SqlConnection connection = new DBconnector().GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Customer (C_Name, C_Contact, C_password) OUTPUT INSERTED.C_Id VALUES (@name, @contact,@password)", connection);

                // Adding parameters
                command.Parameters.AddWithValue("@name", c.Name);
                command.Parameters.AddWithValue("@contact", c.Contact);
                command.Parameters.AddWithValue("@password", c.Password);

                command.ExecuteNonQuery();
                MessageBox.Show("Customer Registered Successfully");

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static void update_customerDetails(Customer c)
        {
            SqlConnection connection = new DBconnector().GetConnection();
            try
            {
                connection.Open();

                // Check if the ID exists
                SqlCommand command1 = new SqlCommand("SELECT COUNT(*) FROM Customer WHERE C_Id = @Id", connection);
                command1.Parameters.AddWithValue("@Id", c.Customer_ID);

                int rows = (int)command1.ExecuteScalar();
                if (rows == 0)
                {
                    MessageBox.Show("Customer with ID " + c.Customer_ID + " does not exist.");
                    return;
                }
                else
                {
                    SqlCommand command = new SqlCommand("UPDATE Customer SET C_Name = @name, C_Contact = @contact WHERE C_Id = @Id", connection);

                    // Adding parameters
                    command.Parameters.AddWithValue("@name", c.Name);
                    command.Parameters.AddWithValue("@contact", c.Contact);
                    command.Parameters.AddWithValue("@Id", c.Customer_ID);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Customer Details Updated Successfully");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
