using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Lizard : Reptile
    {
        public Lizard(string classification, string individual, string name) 
            : base(classification, individual)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
