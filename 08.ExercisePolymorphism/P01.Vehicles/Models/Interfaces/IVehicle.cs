using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Models.Interfaces
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }

        public string Drive(double disctance);
        public void Refuel(double liters);
    }
}
