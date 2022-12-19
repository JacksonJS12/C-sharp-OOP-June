using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> models;
        public UniversityRepository()
        {
            this.models = new List<IUniversity>();
        }
        public IReadOnlyCollection<IUniversity> Models
            => this.models;


        public void AddModel(IUniversity model)
            => this.models.Add(model);

        public IUniversity FindById(int id)
            => this.models.FirstOrDefault(u => u.Id == id);

        public IUniversity FindByName(string name)
            => this.models.FirstOrDefault(u => u.Name == name);
    }
}
