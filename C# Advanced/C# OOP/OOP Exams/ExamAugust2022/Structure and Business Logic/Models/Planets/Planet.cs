using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;
        private IRepository<IMilitaryUnit> units;
        private IRepository<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower
        {
            get { return militaryPower; }
            private set
            {
                militaryPower = units.Models.Select(u => u.EnduranceLevel).Sum() + weapons.Models.Select(w => w.DestructionLevel).Sum();

                if (units.Models.Any(u => u.GetType().Name == "AnonymousImpactUnit"))
                {
                    militaryPower *= 0.7;
                }

                if (weapons.Models.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    militaryPower *= 55;
                }

                militaryPower = Math.Round(militaryPower, 3);
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.AppendLine(units.Models.Count > 0 ? $"--Forces: {string.Join("  ", units.Models)}" : "No units");
            sb.AppendLine(weapons.Models.Count > 0 ? $"--Combat equipment: {string.Join("  ", weapons.Models)}" : "No weapons");
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            try
            {
                Budget -= amount;
            }
            catch (ArgumentException)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
        }

        public void TrainArmy()
        {
            units.Models.ToList().ForEach(u => u.IncreaseEndurance());
        }
    }
}
