using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            this.subjects = new SubjectRepository();
            this.students = new StudentRepository();
            this.universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            IStudent student = new Student(1, firstName, lastName);

            bool isThere = this.students.FindByName(firstName+" "+lastName) != null;
            if (isThere)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName));
            }

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, this.students);
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            ISubject subject;
            if (subjectType == "TechnicalSubject")
            {
                subject = new TechnicalSubject(1, subjectName);
            }
            else if (subjectType == "EconomicalSubject")
            {
                subject = new EconomicalSubject(1, subjectName);
            }
            else if (subjectType == "HumanitySubject")
            {
                subject = new HumanitySubject(1, subjectName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(OutputMessages.SubjectTypeNotSupported, subjectType));
            }

            bool isThere = this.subjects.FindByName(subjectName) != null;
            if (isThere)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.AlreadyAddedSubject, subjectName));
            }

            this.subjects.AddModel(subject);
            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, this.subjects);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            var requiredSubjectsId = new List<int>();
            foreach (var requiredSubject in requiredSubjects)
            {
                ISubject subject;
                if (category == "Humanity")
                {
                    subject = new HumanitySubject(1, requiredSubject);
                }
                else if (category == "Technical")
                {
                    subject = new TechnicalSubject(1, requiredSubject);
                }
                subject = new EconomicalSubject(1, requiredSubject);

                requiredSubjectsId.Add(subject.Id);
            }

            IUniversity university = new University(1, universityName, category, capacity, requiredSubjectsId);

            bool isThere = this.universities.FindByName(universityName) != null;
            if (isThere)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.AlreadyAddedUniversity, universityName));
            }

            this.universities.AddModel(university);
            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, this.universities);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string studentFirstName = studentName.Split()[0];
            string studentLastName = studentName.Split()[1];
            IStudent student = this.students.FindByName(studentName);
            IUniversity university = this.universities.FindByName(universityName);
            if (student == null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.StudentNotRegitered, studentFirstName, studentLastName));
            }
            else if (university == null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.UniversityNotRegitered, universityName)); ;
            }
            else if (student.CoveredExams != university.RequiredSubjects)
            {
                throw new InvalidCastException(string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName));
            }
            else if (student.University == university)
            {
                throw new InvalidCastException(string.Format(OutputMessages.StudentAlreadyJoined, studentFirstName, studentLastName, universityName)); ;
            }

            student.JoinUniversity(university);
            return string.Format(OutputMessages.StudentSuccessfullyJoined, studentFirstName, studentLastName, universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            var student = this.students.FindById(studentId);
            var subject = this.subjects.FindById(subjectId);

            if (student == null)
            {
                throw new InvalidOperationException(OutputMessages.InvalidStudentId);
            }

            if (subject == null)
            {
                throw new InvalidOperationException(OutputMessages.InvalidSubjectId);
            }

            if (student.CoveredExams.Contains(subjectId))
            {
                throw new InvalidOperationException(string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name)); ;
            }

            student.CoverExam(subject);
            this.students.AddModel(student);

            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = this.universities.FindById(universityId);

            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"*** {university.Name} ***")
                .AppendLine($"Profile: {university.Category}")
                .AppendLine($"Students admitted: {university.Capacity}")
                .AppendLine($"University vacancy: {university.Capacity}");

            return sb.ToString().TrimEnd();
        }
    }
}
