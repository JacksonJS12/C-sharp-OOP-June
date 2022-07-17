using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace P04.WildFarm
{
    public class FoodNotPreferredException : Exception
    {
        public FoodNotPreferredException(string message)
            : base(message)
        {

        }
    }
}

