using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using P01.Heroes.Models.Heroes;
using P01.Heroes.Models.Map;
using P01.Heroes.Models.Weapons;
using P01.Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01.Heroes.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes;
        private readonly IRepository<IWeapon> weapens;

        public Controller()
        {
            this.heroes = new HeroRepository();
            this.weapens = new WeaponRepository();
            
        }
        public string CreateHero(string type, string name, int health, int armour)
        {
            if (this.heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            //alternative variant of 3 if cases
            IHero hero = type switch
            {
                nameof(Knight) => new Knight(name, health, armour),
                nameof(Barbarian) => new Barbarian(name, health, armour),
                _ => throw new InvalidOperationException("Invalid hero type.")
            };

            this.heroes.Add(hero);

            var heroAlias = type == nameof(Knight)
                ? $"Sir {hero.Name}"
                : $"{nameof(Barbarian)} {hero.Name}";

            return $"Successfully added {heroAlias} to the collection.";
        }
        public string CreateWeapon(string type, string name, int durability)
        {
            if (this.heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }
            IWeapon weapon = type switch
            {
                nameof(Mace) => new Mace(name, durability),
                nameof(Claymore) => new Claymore(name, durability),
                _ => throw new InvalidOperationException("Invalid weapon type.")
            };

            this.weapens.Add(weapon);

            return $"A {type.ToLower()} {name} is added to the collection.";

        }
        public string AddWeaponToHero(string weaponName, string heroName)
        { 
            var hero = this.heroes.FindByName(heroName);
            var weapon = this.weapens.FindByName(weaponName);
            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            if(hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            hero.AddWeapon(weapon);

            this.weapens.Remove(weapon);

            var weaponType = weapon.GetType().Name;

            return $"Hero {heroName} can participate in battle using a {weaponType.ToLower()}.";

        }

        
        public string StartBattle()
        {
            var map = new Map();

            var heroesReadyForBattle = 
                this.heroes
                .Models
                .Where(h => h.IsAlive && h.Weapon != null)
                .ToList();

            return map.Fight(heroesReadyForBattle);
        }


        public string HeroReport()
        {
            var result = new StringBuilder();

            var sprtedHeroes = this.heroes
                .Models
                .OrderBy(h => h.GetType().Name)
                .ThenBy(h => h.Name);
             
            foreach (var hero in sprtedHeroes)
            {
                result.AppendLine(hero.ToString());
            }

            return result.ToString().Trim();
        }

    }
}
