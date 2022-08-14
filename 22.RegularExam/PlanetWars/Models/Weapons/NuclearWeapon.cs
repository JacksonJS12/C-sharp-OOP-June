using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        private const double Price = 15;
        private int destructionLevel;
        public NuclearWeapon( int destructionLevel) 
            : base(Price, destructionLevel)
        {
        }

        public override int DestructionLevel
        {
            get
            {
                return this.destructionLevel;
            }
             set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }
                else if (value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }
                this.destructionLevel = value;
            }
        }
    }
}
