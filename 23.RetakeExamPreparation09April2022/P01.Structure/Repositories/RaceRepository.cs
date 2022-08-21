using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly ICollection<IRace> models;
        private RaceRepository()
        {
            this.models = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models
            => (IReadOnlyCollection<IRace>)this.models;

        public void Add(IRace pilot)
            => this.models.Add(pilot);

        public IRace FindByName(string name)
            => this.models.FirstOrDefault(r => r.RaceName == name);


        public bool Remove(IRace model)
            => this.models.Remove(model);
    }
}
