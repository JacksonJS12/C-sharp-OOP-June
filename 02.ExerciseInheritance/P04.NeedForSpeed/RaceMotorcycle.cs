using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int hoursePower, double fuel, double fuelConsumption = 8)
            : base(hoursePower, fuel, fuelConsumption)
        {
        }
    }
}
