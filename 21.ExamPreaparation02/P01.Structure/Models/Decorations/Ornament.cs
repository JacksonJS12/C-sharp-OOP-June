using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int Confort = 1;
        private const decimal Price = 5;
        public Ornament() 
            : base(Confort, Price)
        {
        }
    }
}
