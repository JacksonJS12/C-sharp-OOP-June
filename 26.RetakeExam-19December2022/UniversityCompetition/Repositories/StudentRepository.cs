using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> models;
        public StudentRepository()
        {
            this.models = new List<IStudent>();
        }
        public IReadOnlyCollection<IStudent> Models
            => this.models;

        public void AddModel(IStudent model)
            => this.models.Add(model);

        public IStudent FindById(int id)
            => this.models.FirstOrDefault(m => m.Id == id);

        public IStudent FindByName(string name)
        {
            string first = name.Split()[0];
            string last = name.Split()[1];

            return this.models
                .FirstOrDefault(m =>
                m.FirstName == first && 
                m.LastName == last);
        }
    }
}
