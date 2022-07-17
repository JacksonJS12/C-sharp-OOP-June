using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm
{
    public class Cat : Feline
    {
        private const double catWeightMultiplier = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override IReadOnlyCollection<Type> PreferredFoods 
            => new List<Type> { typeof(Vegetable), typeof(Meat)}.AsReadOnly();

        protected override double WeightMultiplier
            => catWeightMultiplier;

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
