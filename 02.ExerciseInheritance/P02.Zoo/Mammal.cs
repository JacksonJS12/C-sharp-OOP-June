using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Mammal : Animal
    {
        public Mammal(string classification, string individual) 
            : base(classification)
        {
            this.Individual = individual;
        }

        public string Individual { get; set; }
    }
}
