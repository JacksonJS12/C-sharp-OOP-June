using Heroes.IO;
using Heroes.Models.Contracts;
using P01.Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01.Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            var knights = new List<Knight>();
            var barbarians = new List<Barbarian>();

            foreach (var player in players)
            {
                if (player.IsAlive)
                {
                    if (player is Knight knight)
                    {
                        knights.Add(knight);
                    }
                    else if (player is Barbarian barbarian)
                    {
                        barbarians.Add(barbarian);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid hero type!");
                    }
                }
            }

            var continueBattle = true;

            while (continueBattle)
            {
                var allKnightsAreDead = true;
                var allBarberiansAreDead = true;

                var aliveKnights = 0;
                var aliveBarberians = 0;
                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        allKnightsAreDead = false;
                        aliveKnights++;
                        foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                        {
                            var weopenDamage = knight.Weapon.DoDamage();

                            barbarian.TakeDamage(weopenDamage);
                        }
                    }
                }

                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        allBarberiansAreDead = false;
                        aliveBarberians++;

                        foreach (var knight in knights.Where(kn => kn.IsAlive))
                        {
                            var weapenDamage = barbarian.Weapon.DoDamage();

                            knight.TakeDamage(weapenDamage);
                        }
                    }
                }

                if (allBarberiansAreDead)
                {
                    var deathBarbarians = barbarians.Count - aliveBarberians;
                    return $"The barbarians took {deathBarbarians} casualties but won the battle.";
                }
                else if (allKnightsAreDead)
                {
                    var deathKnights = knights.Count - aliveKnights;
                    return $"The knights took {deathKnights} casualties but won the battle.";
                }
            }
            throw new InvalidOperationException("The fight logic has a bug"); 
        }
    }
}
