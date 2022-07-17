using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm
{
    public interface IAnimalFactory
    {
        public Animal CreateAnimal
            (string type, string name, double weight,
            string thirdParam, string forthParam = null);
    }
}
