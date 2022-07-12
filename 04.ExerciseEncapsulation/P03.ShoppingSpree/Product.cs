using System;
using System.Collections.Generic;
using System.Text;

namespace P03.ShoppingSpree
{
    public class Product
    {
        private string name;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Cost { get; private set; }
    }
}
