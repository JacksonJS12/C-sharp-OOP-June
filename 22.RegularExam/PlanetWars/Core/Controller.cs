using PlanetWars.Core.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.Planets.Contracts;
using System.Linq;
using PlanetWars.Models.MilitaryUnits.Contracts;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            this.planets = new PlanetRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IMilitaryUnit militaryUnit;
            if (unitTypeName == "AnonymousImpactUnit")
            {
                militaryUnit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == "SpaceForces")
            {
                militaryUnit = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                militaryUnit = new StormTroopers();
            }

            IPlanet planet = this.planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(ExceptionMessages.UnexistingPlanet);
            }

            bool isAvaible = false;
            foreach (var unit in planet.Army)
            {
                if (unit.GetType().Name == unitTypeName)
                {
                    isAvaible = true;
                }
            }

            if (isAvaible == false)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemNotAvailable);
            }
            return "";
           
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            throw new NotImplementedException();
        }

        public string CreatePlanet(string name, double budget)
        {
            Planet planet = new Planet(name, budget);
            if (this.planets.FindByName(name) == null)
            {
                return OutputMessages.ExistingPlanet;
            }
            this.planets.AddItem(planet);
            return OutputMessages.NewPlanet;
        }

        public string ForcesReport()
        {
            throw new NotImplementedException();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            throw new NotImplementedException();
        }

        public string SpecializeForces(string planetName)
        {
            throw new NotImplementedException();
        }
    }
}
