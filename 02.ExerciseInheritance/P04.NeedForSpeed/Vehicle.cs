using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double defaultFuelConsumption = 1.25;
        private double fuelConsuption;
        public Vehicle(int hoursePower, double fuel)
        {
            this.HoursePower = hoursePower;
            this.Fuel = fuel;
            
        }

        public int HoursePower { get; set; }
        public double Fuel { get; set; }
        public virtual double FuelConsumption 
        { 
            get
            {
                return fuelConsuption;
            }
            set
            {
                fuelConsuption = defaultFuelConsumption;
            }
        }
        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
