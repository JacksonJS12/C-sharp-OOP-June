using System;

namespace P04.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IFoodFactory foodFactory = new FoodFactory();
            IAnimalFactory animalFactory = new AnimalFactory();

            Engine engine = new Engine(foodFactory, animalFactory);
            engine.Start();
        }
    }
}
