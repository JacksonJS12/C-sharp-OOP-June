using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class CrossMotorcycle : Motorcycle
    {
        public CrossMotorcycle(int hoursePower, double fuel, double fuelConsumption) 
            : base(hoursePower, fuel, fuelConsumption)
        {
        }
    }
}
