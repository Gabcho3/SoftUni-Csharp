using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets = new PlanetRepository();

        public string AddUnit(string unitTypeName, string planetName)
        {
            List<string> allunitTypeNames = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && t.Namespace == "PlanetWars.Models.MilitaryUnits")
                .Select(t => t.Name).ToList();

            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (!allunitTypeNames.Contains(unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == unitTypeName);
            IMilitaryUnit unit = Activator.CreateInstance(type) as IMilitaryUnit;

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);

        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            List<string> allweaponTypeNames = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && t.Namespace == "PlanetWars.Models.Weapons")
                .Select(t => t.Name).ToList();

            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (!allweaponTypeNames.Contains(weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == weaponTypeName);
            IWeapon weapon = Activator.CreateInstance(type, new object[] {destructionLevel}) as IWeapon;

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = new Planet(name, budget);

            if (planets.Models.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.ExistingPlanet, planet.Name);
            }

            planets.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet, planet.Name);
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach(var planet in planets.Models)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet declaratorOfWar = planets.FindByName(planetOne);
            IPlanet defender = planets.FindByName(planetTwo);
            IPlanet winner;
            IPlanet looser;

            if (declaratorOfWar.MilitaryPower == defender.MilitaryPower)
            {
                bool declaratorHasWeapon = declaratorOfWar.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");
                bool defenderHasWeapon = defender.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");

                if ((declaratorHasWeapon && defenderHasWeapon) || (!declaratorHasWeapon && !defenderHasWeapon))
                {
                    declaratorOfWar.Spend(declaratorOfWar.Budget / 2);
                    defender.Spend(defender.Budget / 2);

                    return OutputMessages.NoWinner;
                }

                winner = declaratorHasWeapon ? declaratorOfWar : defender;
                looser = winner == declaratorOfWar ? defender : declaratorOfWar;
            }

            else
            {
                winner = declaratorOfWar.MilitaryPower > defender.MilitaryPower ? declaratorOfWar : defender;
                looser = winner == declaratorOfWar ? defender : declaratorOfWar;
            }

            winner.Spend(winner.Budget / 2);
            winner.Profit(looser.Budget / 2);
            winner.Profit(looser.Army.Select(a => a.Cost).Sum() + looser.Weapons.Select(w => w.Price).Sum());

            planets.RemoveItem(looser.Name);
            return string.Format(OutputMessages.WinnigTheWar, winner.Name, looser.Name);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidPlanetName, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Army.ToList().ForEach(a => a.IncreaseEndurance());
            planet.Spend(1.25);
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
