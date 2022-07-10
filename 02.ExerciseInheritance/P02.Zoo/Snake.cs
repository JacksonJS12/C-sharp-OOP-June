using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Snake : Reptile
    {
        public Snake(string classification, string individual, string name)
            : base(classification, individual)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
