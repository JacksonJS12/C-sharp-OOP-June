using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm
{
    public class Cat : Feline
    {
        private const double catWeightMultiplier = 0.30;
        public Cat(string name, double weight, string livingRegion, string bread)
            : base(name, weight, livingRegion, bread)
        {
        }

        protected override IReadOnlyCollection<Type> PrefferdFoods 
            => new List<Type> { typeof(Vegetable), typeof(Meat)}.AsReadOnly();

        protected override double WeightMultiplier
            => catWeightMultiplier;

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
