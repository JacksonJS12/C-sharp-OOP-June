using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private string name;
        private string category;
        private int capacity;
        private int id;
        private IReadOnlyCollection<int> requiredSubjects;

        public University(int id, string name, string category, int capacity, IReadOnlyCollection<int> requiredSubjects)
        :this()
        {
            this.requiredSubjects = requiredSubjects;
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Capacity = capacity;
        }
        public University()
        {

        }

        public int Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                this.id += value;
            }
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
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                this.name = value;
            }
        }

        public string Category
        {
            get
            {
                return this.category;
            }
           private set
            {
                if(value != "Technical" && value != "Economical" && value != "Humanity") 
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed, value));
                }
                this.category = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityNegative); ;
                }
                this.capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects 
            => this.requiredSubjects;

        
    }
}
