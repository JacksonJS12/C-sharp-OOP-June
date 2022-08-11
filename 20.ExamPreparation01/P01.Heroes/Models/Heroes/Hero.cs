﻿using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                this.health = value;
            }
        }

        public int Armour
        {
            get => this.armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                this.armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => this.Weapon;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Weapon cannot be null.");
                }
                this.weapon = value;
            }
        }


        public bool IsAlive => this.Health > 0;

        public void AddWeapon(IWeapon weapon)
            => this.Weapon = weapon;

        public void TakeDamage(int points)
        {
            var armourLeft = this.Armour - points;

            if (armourLeft < 0)
            {
                this.Armour = 0;

                var healthLeft = this.Health + armourLeft;
                if (healthLeft < 0)
                {
                    this.Health = 0;
                }
                else
                {
                    this.Health = healthLeft;
                }
            }
            else
            {
                this.Armour = armourLeft;
            }

        }
        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{this.GetType().Name}: {this.Name}");
            result.AppendLine("--Health: { hero health }");
            result.AppendLine("--Armour: { hero armour }");
            result.AppendLine("--Weapon: { weapon name }/Unarmed");
        }}
    }
}