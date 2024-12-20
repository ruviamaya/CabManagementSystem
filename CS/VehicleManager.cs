using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB011911.CS
{
    internal class VehicleManager
    {
        public static void add_vehicle(Vehicle v) 
        {
            SqlConnection connection = new DBconnector().GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Vehicle (V_Model, V_PlateNo, V_Availability) OUTPUT INSERTED.V_Id VALUES (@model, @plate, @availability)", connection);

                // Adding parameters
                command.Parameters.AddWithValue("@model", v.Model);
                command.Parameters.AddWithValue("@plate", v.PlateNo);
                command.Parameters.AddWithValue("@availability", v.Availability);
                
                command.ExecuteNonQuery();
                MessageBox.Show("Vehicle Added Successfully");

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
        public static void update_vehicle(Vehicle v) 
        {
            SqlConnection connection = new DBconnector().GetConnection();
            try
            {
                connection.Open();

                // Check if the ID exists
                SqlCommand command1 = new SqlCommand("SELECT COUNT(*) FROM Vehicle WHERE V_Id = @Id", connection);
                command1.Parameters.AddWithValue("@Id", v.VehicleID);

                int rows = (int)command1.ExecuteScalar();
                if (rows == 0)
                {
                    MessageBox.Show("Vehicle with ID " + v.VehicleID + " does not exist.");
                    return;
                }
                else
                {
                    SqlCommand command = new SqlCommand("UPDATE Vehicle SET V_Model = @model, V_PlateNO = @plate, V_Availability = @availability WHERE V_Id = @Id", connection);

                    // Adding parameters
                    command.Parameters.AddWithValue("@model", v.Model);
                    command.Parameters.AddWithValue("@plate", v.PlateNo);
                    command.Parameters.AddWithValue("@availability", v.Availability);
                    command.Parameters.AddWithValue("@Id", v.VehicleID);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Vehicle Updated Successfully");
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
        public static void delete_vehicle(int id) 
        {
            SqlConnection connection = new DBconnector().GetConnection();
            try
            {
                connection.Open();

                // Check if the ID exists
                SqlCommand command1 = new SqlCommand("SELECT COUNT(*) FROM Vehicle WHERE V_Id = @Id", connection);
                command1.Parameters.AddWithValue("@Id", id);

                int rows = (int)command1.ExecuteScalar();
                if (rows == 0)
                {
                    MessageBox.Show("Vehicle with ID " + id + " does not exist.");
                    return;
                }
                else
                {
                    SqlCommand command = new SqlCommand("DELETE FROM Vehicle WHERE V_Id = @Id", connection);

                    // Adding parameters
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Vehicle Deleted Successfully");
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

        public static void view_vehicles(DataGridView dataGridView)
        {
            SqlConnection connection = new DBconnector().GetConnection();
            try
            {
                connection.Open();
                string selectAllQuery = "SELECT * FROM Vehicle";

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


        public static DataTable viewVehicleByID(int id)
        {
            SqlConnection connection = new DBconnector().GetConnection();
            DataTable dataTable = new DataTable();
            try
            {
                connection.Open();

                // Check if the ID exists
                SqlCommand command1 = new SqlCommand("SELECT COUNT(*) FROM Vehicle WHERE V_Id = @Id", connection);
                command1.Parameters.AddWithValue("@Id", id);

                int rows = (int)command1.ExecuteScalar();
                if (rows == 0)
                {
                    MessageBox.Show("Vehicle with ID " + id + " does not exist.");
                }
                else
                {
                    string selectAllQuery = "SELECT * FROM Vehicle WHERE V_Id = @id";

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

        public static DataTable viewAvailableVehicles()
        {
            SqlConnection connection = new DBconnector().GetConnection();
            string query = "SELECT * FROM Vehicle WHERE V_Availability = 1";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }


        //update availability when vehicle is chosen
        public static void Update_VehicleAvailability(int id, bool availability)
        {
            SqlConnection connection = new DBconnector().GetConnection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Vehicle SET V_Availability = @availability WHERE V_Id = @Id", connection);

                // Adding parameters
                command.Parameters.AddWithValue("@availability", availability);
                command.Parameters.AddWithValue("@Id", id);
                
                command.ExecuteNonQuery();
                //MessageBox.Show("Vehicle Availability Updated Successfully");
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

        //To check if the entered vehicle is available when booking a trip 
        public static int check_availability(int id)
        {
            SqlConnection connection = new DBconnector().GetConnection();
            try
            {
                connection.Open();
                string selectQuery = "SELECT COUNT(*) FROM Vehicle WHERE V_Id = @Id AND V_Availability = 1";

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
