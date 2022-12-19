using System;
using System.Collections.Generic;
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
        private IReadOnlyCollection<int> requiredSubjects;

        public University(IReadOnlyCollection<int> requiredSubjects, int id, string name, string category, int capacity)
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

        public int Id { get; private set; }//return later

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
            set
            {
                if (value == "Technical")
                {

                }
                else if (value == "Economical")
                {

                }
                else if (value == "Humanity")
                {

                }
                else 
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
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityNegative); ;
                }
                this.capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects => throw new NotImplementedException();

        
    }
}
