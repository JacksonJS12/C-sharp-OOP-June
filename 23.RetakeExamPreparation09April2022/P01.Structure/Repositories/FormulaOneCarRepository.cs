using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly ICollection<IFormulaOneCar> models;
        private FormulaOneCarRepository()
        {
            this.models = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models
            => (IReadOnlyCollection<IFormulaOneCar>)this.models;

        public void Add(IFormulaOneCar model)
            => this.models.Add(model);

        public IFormulaOneCar FindByName(string model)
            => this.models.FirstOrDefault(m => m.Model == model);

        public bool Remove(IFormulaOneCar car)
            => this.models.Remove(car);

    }
}
