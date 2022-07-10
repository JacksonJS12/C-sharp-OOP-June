using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string animalType = Console.ReadLine();
            while (animalType != "Beast!")
            {
                try
                {
                    string[] animalInfo = Console.ReadLine()
                   .Split()
                   .ToArray();
                    string name = animalInfo[0];
                    int age = int.Parse(animalInfo[1]);

                    Animal animal;
                    if (animalType == "Dog")
                    {
                        string gender = animalInfo[2];
                        animal = new Dog(name, age, gender);
                        animals.Add(animal);
                    }
                    else if (animalType == "Frog")
                    {
                        string gender = animalInfo[2];
                        animal = new Frog(name, age, gender);
                        animals.Add(animal);
                    }
                    else if (animalType == "Cat")
                    {
                        string gender = animalInfo[2];
                        animal = new Cat(name, age, gender);
                        animals.Add(animal);
                    }
                    else if (animalType == "Kitten")
                    {
                        animal = new Kittens(name, age);
                        animals.Add(animal);
                    }
                    else if (animalType == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                        animals.Add(animal);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }

                animalType = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", animals));
        }
    }
}
