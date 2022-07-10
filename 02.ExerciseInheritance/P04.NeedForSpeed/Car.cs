using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int hoursePower, double fuel, double fuelConsuption = 3)
            : base(hoursePower, fuel, fuelConsuption)
        {
        }
    }
}
