using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Structure.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int InitSize = 5;
        private const int InitIncreaseSize = 2;
        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = InitSize;
        }

        public override void Eat()
            => this.Size += InitIncreaseSize;

        //Can only live in SaltwaterAquarium!
    }
}
