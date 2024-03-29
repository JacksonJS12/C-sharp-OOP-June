﻿using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public abstract class Subject : ISubject
    {
        private string name;
        private int id;

        protected Subject(int id, string name, double rate)
        {
            this.Id = id;
            this.Name = name;
            this.Rate = rate;
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

        public double Rate { get; private set; }
    }
}
