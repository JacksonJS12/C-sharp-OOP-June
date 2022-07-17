using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm
{
    public interface IFoodFactory
    {
        Food CreateFood(string type, int quantity);
    }
}
