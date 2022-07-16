namespace Vehicle.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Vehicle.Models;
    using Vehicle.Models.Interfaces;
    public class VehicleFactory : IVehicleFactory
    {
        public Models.Interfaces.Vehicle CreateVehicle(string vehicleType, 
            double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle;

            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }
            else
            {
                throw new InvalidOperationException("Invalid vehicle type!");
            }
            return vehicle;
        }
    }
}
