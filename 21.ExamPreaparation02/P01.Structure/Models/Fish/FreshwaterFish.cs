using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int InitSize = 3;
        private const int InitIncreaseSize = 3;
        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = InitSize;
        }

        public override void Eat()
            => this.Size += InitIncreaseSize;

        //Can only live in FreshwaterAquarium!
    }
}
