using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        private int age;
        private string name;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Age = age;
            this.Name = name;
            this.Birthdate = birthdate;
            this.Id = id;
        }

        public int Age
        {
            get
            {
                return this.age;
            }
             set
            {
                this.age = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }
    }
}
