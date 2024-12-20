using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB011911.CS
{
    internal class Admin
    {
        //Attributes
       // private int admin_id;
       // private string name;
        //private string password;

        //properties
       /* public int AdminID
        {
            get { return admin_id; }
            set { admin_id = value; }
        }*/

        /*public string Name
        {
            get { return name; }
            set { name = value; }
        }*/

        /*public string Password
        {
            get { return password; }
            set { password = value; }
        }
        int id, string name, string password
            admin_id = id;
            this.name = name;
            this.password = password;*/

        //Constructor
        public Admin()
        {
            
        }


        public static void view_order(DataGridView dataGridView) 
        {
            SqlConnection connection = new DBconnector().GetConnection();
            try
            {
                connection.Open();
                string selectAllQuery = "SELECT * FROM Orders";

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
    }
}
