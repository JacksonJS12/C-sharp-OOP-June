using System;
using System.Collections.Generic;
using System.Text;

namespace P03.ShoppingSpree
{
    public class Person
    {
        private readonly List<Product> bagOfProducts;
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            this.bagOfProducts = new List<Product>();
            this.Name = name;
            this.Money = money;
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
        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public void AddProductToTheBag(Product product)
        {
            if (!CanIBuyThis(product))
            {
                throw new ArgumentException($"{this.Name} can't afford {product.Name}");
            }
            this.Money -= product.Cost;
            this.bagOfProducts.Add(product);
            Console.WriteLine($"{this.Name} bought {product.Name}");
        }

        private bool CanIBuyThis(Product product)
        {
            if (this.Money - product.Cost > this.Money)
            {
                return true;
            }
            return false;
        }
    }
}
