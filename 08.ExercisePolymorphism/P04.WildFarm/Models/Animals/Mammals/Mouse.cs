using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm
{
    public class Mouse : Mammal
    {
        private const double MouseWeightMultipler = 0.10;
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override IReadOnlyCollection<Type> PrefferdFoods
            => new List<Type> { typeof(Fruit), typeof(Vegetable) };

        protected override double WeightMultiplier 
            => MouseWeightMultipler;

        public override string ProduceSound()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
