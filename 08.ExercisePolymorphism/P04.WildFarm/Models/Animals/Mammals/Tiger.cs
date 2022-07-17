using System;
using System.Collections.Generic;
using System.Text;

namespace P04.WildFarm
{
    public class Tiger : Feline
    {
        private const double TigerWeightMultiplier = 1;
        public Tiger(string name, double weight, string livingRegion, string bread)
            : base(name, weight, livingRegion, bread)
        {
        }

        protected override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type> { typeof(Meat) }.AsReadOnly();

        protected override double WeightMultiplier 
            => TigerWeightMultiplier;

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
