using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double defaultFuelConsumption = 8;
        public RaceMotorcycle(int hoursePower, double fuel)
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
