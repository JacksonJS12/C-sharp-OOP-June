﻿using System;
using System.Collections.Generic;
namespace P04.WildFarm
{
    public class Hen : Bird
    {
        private const double HenWeightMultiplier = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        protected override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type>
                    { typeof(Fruit), typeof(Meat), typeof(Seeds), typeof(Vegetable) }
                .AsReadOnly();

        protected override double WeightMultiplier
            => HenWeightMultiplier;

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}