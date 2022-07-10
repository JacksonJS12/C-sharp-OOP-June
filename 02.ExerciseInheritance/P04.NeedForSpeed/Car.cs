using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double defaultFuelConsumption = 3;
        public Car(int hoursePower, double fuel)
            : base(hoursePower, fuel)
        {
            this.FuelConsumption = defaultFuelConsumption;
        }

        public override double FuelConsumption 
        { 
            get => base.FuelConsumption;
            set => base.FuelConsumption = value; 
        }
    }
}
