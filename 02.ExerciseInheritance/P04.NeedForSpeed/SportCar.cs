using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int hoursePower, double fuel, double fuelConsuption = 10) 
            : base(hoursePower, fuel, fuelConsuption)
        {
        }
    }
}
