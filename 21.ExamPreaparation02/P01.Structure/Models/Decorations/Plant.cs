using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int Confort = 5;
        private const decimal Price = 10;
        public Plant() 
            : base(Confort, Price)
        {
        }
    }
}
