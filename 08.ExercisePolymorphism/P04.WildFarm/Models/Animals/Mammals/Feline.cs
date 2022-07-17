using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string bread)
            : base(name, weight, livingRegion)
        {
            this.Bread = bread;
        }
        public  string Bread { get; }
        public override string ToString()
        {
            return base.ToString() + $"{this.Bread}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
