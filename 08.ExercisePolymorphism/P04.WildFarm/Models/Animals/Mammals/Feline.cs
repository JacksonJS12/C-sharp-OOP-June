using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed )
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;

        }
        public string Breed { get; }
        public override string ToString()
        {
            return base.ToString()
                + $"{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
