﻿namespace P04.WildFarm
{
    public class AnimalFactory : IAnimalFactory
    {
        public Animal CreateAnimal
            (string type, string name, double weight,
            string thirdParam, string forthParam = null)
        {
            Animal animal;
            if (type == "Owl")
            {
                animal = new Owl(name, weight, double.Parse(thirdParam));
            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, thirdParam);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, weight, thirdParam, forthParam);
            } 
            else if (type == "Tiger")
            {
                animal = new Cat(name, weight, thirdParam, forthParam);
            }
            else
            {
                throw new InvalidFactoryTypeException();
            }
            return animal;
        }
    }
}
