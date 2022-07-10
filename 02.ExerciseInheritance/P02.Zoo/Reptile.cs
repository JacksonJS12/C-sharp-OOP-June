using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Reptile : Animal
    {
        public Reptile(string classification, string individual) 
            : base(classification)
        {
            this.Individual = individual;
        }
        public string Individual { get; set; }
    }
}
