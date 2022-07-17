using P04.WildFarm;
using System;
using System.Collections.Generic;

namespace P04.WildFarm
{
    public class Owl : Bird
    {
        private const double owlWeightMultiplier = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override IReadOnlyCollection<Type> PreferredFoods 
            => new List<Type> { typeof(Meat) }.AsReadOnly();

        protected override double WeightMultiplier 
            => owlWeightMultiplier;

        public override string ProduceSound()
        {
            return $"Hoot Hoot";
        }
    }
}
