﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm
{
    public class Engine : IEngine
    {
        private readonly ICollection<Animal> animals;
        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;

        private Engine()
        {
            this.animals = new List<Animal>();
        }
        public Engine(IFoodFactory foodFactory, IAnimalFactory animalFactory)
            : this()
        {
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
        }
        public void Start()
        {
            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] animalArgs = cmd
                   .Split();
                    string[] foodArgs = Console.ReadLine()
                        .Split();

                    Animal animal = BuildAnimalUsingFactory(animalArgs);
                    Food food = this.foodFactory.CreateFood(foodArgs[0], int.Parse(foodArgs[1]));

                    Console.WriteLine(animal.ProduceSound());

                    this.animals.Add(animal);

                    animal.Eat(food);
                }
                catch (InvalidFactoryTypeException ifte)
                {
                    Console.WriteLine(ifte.Message);
                }
                catch (FoodNotPreferredException fnpe)
                {
                    Console.WriteLine(fnpe.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

            }
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private Animal BuildAnimalUsingFactory(string[] animalArgs)
        {
            Animal animal;
            if (animalArgs.Length == 4)
            {
                string animalType = animalArgs[0];
                string animaName = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);
                string thirdParam = animalArgs[3];
                animal = this.animalFactory.CreateAnimal(animalType, animaName, weight, thirdParam);
            }
            else if (animalArgs.Length == 5)
            {
                string animalType = animalArgs[0];
                string animaName = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);
                string thirdParam = animalArgs[3];
                string forthParam = animalArgs[4];
                animal = this.animalFactory.CreateAnimal(animalType, animaName, weight, thirdParam, forthParam);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }
            return animal;
        }
    }
}
