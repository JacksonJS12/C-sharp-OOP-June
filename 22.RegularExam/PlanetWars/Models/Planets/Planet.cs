using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlanetWars.Models.MilitaryUnits;

namespace PlanetWars.Models.Planets
{
    public  class Planet : IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;

        private string name;
        private double budget;
        private double militaryPower;

        private Planet()
        {
            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
        }

        public Planet(string name, double budget)
            :this()
        {
            this.Name = name;
            this.Budget = budget;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }

        public double Budget
        {
            get
            {
                return this.budget;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                this.budget = value;
            }
        }

        public double MilitaryPower //have problem isn't working
        {
            get 
            { 
                return this.militaryPower;
            }
            private set
            {
                double totalAmount = TotalAmount();
                this.militaryPower = Math.Round(totalAmount, 3);
            }
        }

        private double TotalAmount()
        {
            double totalAmount =
                                this.Army.Sum(u => u.EnduranceLevel)
                                + this.Weapons.Sum(u => u.DestructionLevel);

            foreach (MilitaryUnit unit in this.Army)
            {
                string unitType = unit.GetType().Name;
                if (unitType == "AnonymousImpactUnit")
                {
                    totalAmount -= totalAmount * 0.3;
                }
            }
            foreach (var weapon in this.Weapons)
            {
                string weaponType = weapon.GetType().Name;
                if (weaponType == "NuclearWeapon")
                {
                    totalAmount -= totalAmount * 0.45;
                }
            }

            return totalAmount;
        }

        public IReadOnlyCollection<IMilitaryUnit> Army
            => (IReadOnlyCollection<IMilitaryUnit>)this.units;

        public IReadOnlyCollection<IWeapon> Weapons 
            => (IReadOnlyCollection<IWeapon>)this.weapons;

        public void AddUnit(IMilitaryUnit unit)
            => this.units.AddItem(unit);

        public void AddWeapon(IWeapon weapon)
            => this.weapons.AddItem(weapon);

        public string PlanetInfo()
        {
            var sb = new StringBuilder();

            string unitsOutput = this.Army.Count > 0 ?
                string.Join(", ", this.Army.Select(u => u.GetType().Name))
                : "No units";

            string weaponsOutput = this.Weapons.Count > 0 ?
                string.Join(", ", this.Weapons.Select(w => w.GetType().Name))
                : "No weapons";

            sb
                .AppendLine($"Planet: {this.Name}")
                .AppendLine($"--Budget: {this.Budget} billion QUID")
                .AppendLine($"--Forces: {unitsOutput}")
                .AppendLine($"--Combat equipment: {weaponsOutput}")
                .Append($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
            => this.Budget += amount;

        public void Spend(double amount)
        {
            if (this.Budget - amount < this.Budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (MilitaryUnit unit in this.Army)
            {
                unit.EnduranceLevel++;
            }
        }
    }
}
