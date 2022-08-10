using System;

namespace P03.TemplatePattern
{
    public class SourDough : Bread
    {
        
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for SourDough bread!");
        }
        public override void Bake()
        {
            Console.WriteLine("Baking the SourDough bread! (20 minutes)");
        }

    }
}
