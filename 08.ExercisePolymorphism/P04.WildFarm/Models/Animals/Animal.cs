﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04.WildFarm
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get;}
        public double Weight { get; private set; }
        public int FoodEaten{ get; private set; }
        protected abstract IReadOnlyCollection<Type> PreferredFoods { get; }
        protected abstract double WeightMultiplier { get; }
        public abstract string ProduceSound();
        public void Eat(Food food)
        {
            if (!this.PreferredFoods.Contains(food.GetType()))
            {
                throw new FoodNotPreferredException
                    (string.Format(ExceptionMessages.FoodNotPreffered,
                    this.GetType().Name, food.GetType().Name));
            }
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightMultiplier;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
