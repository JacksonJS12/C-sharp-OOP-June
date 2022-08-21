using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly ICollection<IPilot> models;
        private PilotRepository()
        {
            this.models = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models
            => (IReadOnlyCollection<IPilot>)this.models;

        public void Add(IPilot pilot)
            => this.models.Add(pilot);

        public IPilot FindByName(string fullName)
            => this.models.FirstOrDefault(p => p.FullName == fullName);

        public bool Remove(IPilot pilot)
            => this.models.Remove(pilot);
    }
}
