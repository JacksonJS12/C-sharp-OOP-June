using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        private string firstName;
        private string lastName;
        private IList<int> coveredExams;
        private IUniversity university;

        public Student(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;

            this.coveredExams = new List<int>();
            this.university = new University();
        }

        public int Id { get; private set; } //add repo logic later

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                this.lastName = value;
            }
        }

        public IList<int> CoveredExams
        {
            get
            {
                return this.coveredExams;
            }
        }

        public IUniversity University
        {
            get
            {
                return this.university;
            }
        }

        public void CoverExam(ISubject subject) 
            => this.CoveredExams.Add(subject.Id);

        public void JoinUniversity(IUniversity university) //possible error
        {
            this.university = university;
        }
    }
}
