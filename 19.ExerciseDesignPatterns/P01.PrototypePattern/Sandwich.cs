using System;

namespace P01.PrototypePattern
{
    public class Sandwich : SandwichPrototype
    {
        private readonly string bread;
        private readonly string meat;
        private readonly string chease;
        private readonly string veggies;

        public Sandwich(string bread, string meat, string chease, string veggies )
        {
            this.bread = bread;
            this.meat = meat;
            this.chease = chease;
            this.veggies = veggies;
        }

        public override SandwichPrototype Clone()
        {
            string ingredients = this.GetIngreadientsList();
            //Good to implement Reader
            Console.WriteLine($"Cloning sandwich with ingredients: {ingredients}");

            return (this.MemberwiseClone() as SandwichPrototype)!;
        }
        private string GetIngreadientsList()
        {
            return $"{this.bread}, {this.meat}, {this.chease}, {this.veggies}";
        }
    }
}
