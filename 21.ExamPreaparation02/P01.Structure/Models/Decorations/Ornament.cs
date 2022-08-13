using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Structure.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int CONFORT = 1;
        private const decimal PRICE = 5;
        public Ornament() 
            : base(CONFORT, PRICE)
        {
        }
    }
}
