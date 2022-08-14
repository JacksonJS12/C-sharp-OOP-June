using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private const int InitValue = 1;

        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
        }

        public double Cost { get; }

        public int EnduranceLevel { get; set; }
            = InitValue;

        public void IncreaseEndurance()
        {
            this.EnduranceLevel++;
            if (this.EnduranceLevel + 1 > 20)
            {
                this.EnduranceLevel = 20;
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}
