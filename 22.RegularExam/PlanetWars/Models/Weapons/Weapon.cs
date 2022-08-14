using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private int destructionLevel;

        protected Weapon(double price, int destructionLevel)
        {
            this.Price = price;
            this.destructionLevel = destructionLevel;
        }

        public double Price { get; }

        public abstract int DestructionLevel { get; set; }
        
    }
}
