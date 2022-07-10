using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Bear : Mammal
    {
        public Bear(string classification, string individual, string name)
            : base(classification, individual)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
