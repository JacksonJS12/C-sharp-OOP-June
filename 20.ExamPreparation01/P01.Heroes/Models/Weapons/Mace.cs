using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private const int Damage = 25; 
        public Mace(string name, int durability) 
            : base(name, durability, Damage)
        {
        }

        
    }
}
