using System;

namespace P03.TemplatePattern
{
    public class WholeWheat : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for WholeWheat bread!");
        }
        public override void Bake()
        {
            Console.WriteLine("Baking the WholeWheat bread! (15 minutes)");
        }

    }
}
