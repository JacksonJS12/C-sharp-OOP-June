using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly HashSet<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new HashSet<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models
             => this.models;

        public void Add(IDecoration model)
            => this.models.Add(model);
        public bool Remove(IDecoration model)
             => this.models.Remove(model);

        public IDecoration FindByType(string type)
             => this.models.FirstOrDefault(m => m.GetType().Name == type);

    }
}
