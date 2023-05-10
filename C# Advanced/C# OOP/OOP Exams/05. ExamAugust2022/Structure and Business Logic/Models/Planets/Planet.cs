using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
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
        private UnitRepository units = new UnitRepository();
        private WeaponRepository weapons = new WeaponRepository();

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

        public double MilitaryPower => GetMilitaryPower();

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

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.AppendLine(units.Models.Count > 0 ? $"--Forces: " + string.Join(", ", units.Models.Select(u => u.GetType().Name))
                : "--Forces: No units");
            sb.AppendLine(weapons.Models.Count > 0 ? $"--Combat equipment: " + string.Join(", ", weapons.Models.Select(w => w.GetType().Name))
                : "--Combat equipment: No weapons");
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            else
            {
                Budget -= amount;
            }
        }

        public void TrainArmy()
        {
            units.Models.ToList().ForEach(u => u.IncreaseEndurance());
        }

        private double GetMilitaryPower()
        {
            militaryPower = units.Models.Select(u => u.EnduranceLevel).Sum() + weapons.Models.Select(w => w.DestructionLevel).Sum();

            if (units.Models.Any(u => u.GetType().Name == "AnonymousImpactUnit"))
            {
                militaryPower *= 1.3;
            }

            if (weapons.Models.Any(w => w.GetType().Name == "NuclearWeapon"))
            {
                militaryPower *= 1.45;
            }

            militaryPower = Math.Round(militaryPower, 3);

            return militaryPower;
        }
    }
}
