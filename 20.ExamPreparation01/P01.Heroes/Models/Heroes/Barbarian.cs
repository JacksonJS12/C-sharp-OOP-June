using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Heroes.Models.Heroes
{
    public class Barbarian : Hero
    {
        public Barbarian(string name, int health, int armour) 
            : base(name, health, armour)
        {
        }
    }
}
