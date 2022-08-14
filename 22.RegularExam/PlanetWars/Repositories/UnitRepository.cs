using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private HashSet<IMilitaryUnit> models;
        public UnitRepository()
        {
            this.models = new HashSet<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models
            => this.models;

        public void AddItem(IMilitaryUnit model)
            => this.models.Add(model);

        public IMilitaryUnit FindByName(string name)
            => this.models.FirstOrDefault(m => m.GetType().Name == name);

        public bool RemoveItem(string name)
            => this.models.Remove(this.models.FirstOrDefault(m => m.GetType().Name == name));
    }
}
