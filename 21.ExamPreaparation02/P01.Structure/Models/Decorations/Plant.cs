using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Structure.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int CONFORT = 5;
        private const decimal PRICE = 10;
        public Plant() 
            : base(CONFORT, PRICE)
        {
        }
    }
}
