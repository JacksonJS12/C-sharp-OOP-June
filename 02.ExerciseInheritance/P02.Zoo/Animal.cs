using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Animal
    {
        public Animal(string classification)
        {
            this.Classification = classification;
        }

        public string Classification { get; set; }
    }
}
