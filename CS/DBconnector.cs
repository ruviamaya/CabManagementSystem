using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB011911.CS
{
    internal class DBconnector
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\APIIT\Bsc (Hons) Cyber Security\Year 1\Semester 2\SDAM\Assignment\Final\CB011911\CB011911\CabManagementSystemDatabase.mdf"";Integrated Security=True;Connect Timeout=30";

        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }
    }
}
