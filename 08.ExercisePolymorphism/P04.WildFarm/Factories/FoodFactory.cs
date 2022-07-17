using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm
{
    public class FoodFactory : IFoodFactory
    {
        public Food CreateFood(string type, int quantity)
        {
            Food food;
            if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else
            {
                throw new InvalidFactoryTypeException();
            }

            return food;
        }
    }
}