using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB011911.CS
{
    internal class DriverManager
    {
        public static void add_driver(Driver d)
        {
            SqlConnection connection = new DBconnector().GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Driver (D_Name, D_ContactNo, D_Availability, D_password) OUTPUT INSERTED.D_Id VALUES (@name, @Contact, @availability, @password)", connection);

                // Adding parameters
                command.Parameters.AddWithValue("@name", d.Name);
                command.Parameters.AddWithValue("@contact", d.Contact);
                command.Parameters.AddWithValue("@availability", d.Availability);
                command.Parameters.AddWithValue("@password", d.Password);

                command.ExecuteNonQuery();
                MessageBox.Show("Driver Added Successfully");
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


        public static void update_driver(Driver d)
        {
            SqlConnection connection = new DBconnector().GetConnection();
            try
            {
                connection.Open();

                // Check if the ID exists
                SqlCommand command1 = new SqlCommand("SELECT COUNT(*) FROM Driver WHERE D_Id = @Id", connection);
                command1.Parameters.AddWithValue("@Id", d.DriverID);

                int rows = (int)command1.ExecuteScalar();
                if (rows == 0)
                {
                    MessageBox.Show("Driver with ID " + d.DriverID + " does not exist.");
                    return;
                }
                else
                {
                    SqlCommand command = new SqlCommand("UPDATE Driver SET D_Name = @name, D_ContactNo = @contact, D_Availability = @availability WHERE D_Id = @Id", connection);

                    // Adding parameters
                    command.Parameters.AddWithValue("@name", d.Name);
                    command.Parameters.AddWithValue("@contact", d.Contact);
                    command.Parameters.AddWithValue("@availability", d.Availability);
                    command.Parameters.AddWithValue("@Id", d.DriverID);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Driver Updated Successfully");
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


        public static void delete_driver(int id)
        {
            SqlConnection connection = new DBconnector().GetConnection();
            try
            {
                connection.Open();

                // Check if the ID exists
                SqlCommand command1 = new SqlCommand("SELECT COUNT(*) FROM Driver WHERE D_Id = @Id", connection);
                command1.Parameters.AddWithValue("@Id", id);

                int rows = (int)command1.ExecuteScalar();
                if (rows == 0)
                {
                    MessageBox.Show("Driver with ID " + id + " does not exist.");
                    return;
                }
                else
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Driver WHERE D_Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Driver Deleted Successfully");
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



        public static void view_drivers(DataGridView dataGridView)
        {
            SqlConnection connection = new DBconnector().GetConnection();
            try
            {
                connection.Open();
                string selectAllQuery = "SELECT * FROM Driver";

                SqlDataAdapter adapter = new SqlDataAdapter(selectAllQuery, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView.DataSource = dataTable;
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


        public static DataTable ViewDriverByID(int id)
        {
            SqlConnection connection = new DBconnector().GetConnection();
            DataTable dataTable = new DataTable();
            try
            {
                connection.Open();

                // Check if the ID exists
                SqlCommand command1 = new SqlCommand("SELECT COUNT(*) FROM Driver WHERE D_Id = @Id", connection);
                command1.Parameters.AddWithValue("@Id", id);

                int rows = (int)command1.ExecuteScalar();
                if (rows == 0)
                {
                    MessageBox.Show("Driver with ID " + id + " does not exist.");
                }
                else
                {
                    string selectAllQuery = "SELECT * FROM Driver WHERE D_Id = @id";

                    SqlCommand command = new SqlCommand(selectAllQuery, connection);
                    command.Parameters.AddWithValue("@id", id);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
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
            return dataTable;
        }


        public static DataTable ViewAvailableDrivers()
        {
            SqlConnection connection = new DBconnector().GetConnection();
            string query = "SELECT * FROM Driver WHERE D_Availability = 1";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }


        //update availability when driver is chosen
        public static void Update_DriverAvailability(int id, bool availability)
        {
            SqlConnection connection = new DBconnector().GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Driver SET D_Availability = @availability WHERE D_Id = @Id", connection);

                // Adding parameters
                command.Parameters.AddWithValue("@availability", availability);
                command.Parameters.AddWithValue("@Id", id);
                
                command.ExecuteNonQuery();
                //MessageBox.Show("Driver Availability Updated Successfully");
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

        //To check if the entered driver is available when booking a trip
        public static int check_availability(int id)
        {
            SqlConnection connection = new DBconnector().GetConnection();
            try
            {
                connection.Open();
                string selectQuery = "SELECT COUNT(*) FROM Driver WHERE D_Id = @Id AND D_Availability = 1";

                SqlCommand Command = new SqlCommand(selectQuery, connection);
                Command.Parameters.AddWithValue("@Id", id);

                int rows = (int)Command.ExecuteScalar();
                return rows;

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
