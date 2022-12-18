using Gym.Models.Equipment;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<Equipment>
    {
        private List<Equipment> models;

        public EquipmentRepository()
        {
            this.models = new List<Equipment>();
        }

        public IReadOnlyCollection<Equipment> Models
        { get { return this.models.AsReadOnly(); } }

        public void Add(Equipment model) 
            => this.models.Add(model);

        public Equipment FindByType(string type) 
            => this.models
                        .FirstOrDefault(e => e.GetType().Name == type);

        public bool Remove(Equipment model) 
            => this.models.Remove(model);
    }
}
