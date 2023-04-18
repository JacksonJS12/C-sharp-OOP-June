using System;

namespace VehicleGarage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Garage garage = new Garage(2);
            Vehicle vehicle1 = new Vehicle("Brand", "Model", "1111", 200);
            Vehicle vehicle2 = new Vehicle("Brand", "Model", "0000", 200);

            garage.AddVehicle(vehicle1); 
            garage.DriveVehicle("1111", 20, true);
        }
    }
}
