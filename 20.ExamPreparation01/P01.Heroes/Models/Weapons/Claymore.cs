﻿using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Heroes.Models.Weapons
{
    public class Claymore : Weapon
    {
        private const int Damage = 20;
        public Claymore(string name, int durability, int damage) 
            : base(name, durability, Damage)
        {
        }
    }
}
