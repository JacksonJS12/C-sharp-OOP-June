using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class FamilyCar : Car
    {
        public FamilyCar(int hoursePower, double fuel, double fuelConsuption) 
            : base(hoursePower, fuel, fuelConsuption)
        {
        }
    }
}
