using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB011911.CS
{
    internal class Order
    {
        private int customer_Id;
        private int driver_Id;
        private int vehicle_Id;
        private DateTime dateTime;
        private string pickUpLocation;
        private string dropOffLocation;

        
        //properties
        public int CustomerId
        {
            get { return customer_Id; }
            set { customer_Id = value; }
        }
        public int DriverId
        {
            get { return driver_Id; }
            set { driver_Id = value; }
        }
        public int VehicleId
        {
            get { return vehicle_Id; }
            set { vehicle_Id = value; }
        }
        
        public DateTime DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }

        public string PickUpLocation
        {
            get { return pickUpLocation; }
            set { pickUpLocation = value; }
        }

        public string DropOffLocation
        {
            get { return dropOffLocation; }
            set { dropOffLocation = value; }
        }


        public Order(int customerId, int driverId, int vehicleId,DateTime dateTime, string pickUpLocation, string dropOffLocation)
        {

            customer_Id = customerId;
            driver_Id = driverId;
            vehicle_Id = vehicleId;
            this.dateTime = dateTime;
            this.pickUpLocation = pickUpLocation;
            this.dropOffLocation = dropOffLocation;
        }

        public void SaveOrder(Order order)
        {
            DBconnector dbConnector = new DBconnector();
            SqlConnection sqlConnection = dbConnector.GetConnection();

            string query = "INSERT INTO Orders (Customer_Id,Driver_Id,Vehicle_Id,Order_Date,Location,Destination) OUTPUT INSERTED.Order_Id VALUES (@CustomerId, @DriverId, @VehicleId, @OrderDate, @Location, @Destination)";
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                //adding parameters
                sqlCommand.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                sqlCommand.Parameters.AddWithValue("@DriverId", order.DriverId);
                sqlCommand.Parameters.AddWithValue("@VehicleId", order.VehicleId);
                sqlCommand.Parameters.AddWithValue("@OrderDate", order.DateTime);
                sqlCommand.Parameters.AddWithValue("@Location", order.PickUpLocation);
                sqlCommand.Parameters.AddWithValue("@Destination", order.DropOffLocation);
                
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Order placed!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
