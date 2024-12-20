using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB011911.CS
{
    internal class Vehicle
    {
        private int vehicle_ID;
        private string model;
        private string plateNo;
        private bool availability;

        // Properties
        public int VehicleID
        {
            get { return vehicle_ID; }
            set { vehicle_ID = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string PlateNo
        {
            get { return plateNo; }
            set { plateNo = value; }

        }
        public bool Availability
        {
            get { return availability; }
            set { availability = value; }
        }



        // Constructor
        public Vehicle(string model, string plateNo, bool availability)
        {
            this.model = model;
            this.plateNo = plateNo;
            this.availability = availability;
        }

        //overloaded constructor
        public Vehicle(int vehicle_ID, string model, string plateNo, bool availability)
        {
            this.vehicle_ID = vehicle_ID;
            this.model = model;
            this.plateNo = plateNo;
            this.availability = availability;
        }


    }
}
