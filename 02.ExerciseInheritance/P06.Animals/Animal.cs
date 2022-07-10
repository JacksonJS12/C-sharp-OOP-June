using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;
        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentNullException("Invalid input!");
                }

            }
        }
        public int Age 
        { 
            get
            {
                return age;
            }
            set
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }
        public string Gender 
        { 
            get
            {
                return gender;
            }
            set
            {
                if (value != "Male" || value != "Female")
                {
                    gender = value;
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }
        public abstract string ProduceSound();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"{this.GetType().Name}")
                .AppendLine($"{this.Name} {this.Age} {this.Gender}")
                .Append($"{this.ProduceSound()}");

            return sb.ToString().Trim();
        }
    }
}
