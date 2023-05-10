using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Repositories;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private List<string> heroTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Namespace == "Heroes.Models.Heroes").Select(t => t.Name).ToList();

        private WeaponRepository weapons;
        private List<string> weaponTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.Namespace == "Heroes.Models.Weapons").Select(t => t.Name).ToList();

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.FindByName(heroName);
            if (hero == null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroDoesNotExist, heroName));
            }

            IWeapon weapon = weapons.FindByName(weaponName);
            if(weapon == null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponDoesNotExist, weaponName));
            }

            if(hero.Weapon != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyHasWeapon, heroName));
            }

            weapons.Remove(weapon);
            hero.AddWeapon(weapon);
            return string.Format(OutputMessages.WeaponAddedToHero, heroName, weapon.GetType().Name.ToLower());
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyExist, name));
            }

            if (!heroTypes.Contains(type))
            {
                throw new InvalidOperationException(OutputMessages.HeroTypeIsInvalid);
            }

            Type typeOfHero = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);
            IHero hero = Activator.CreateInstance(typeOfHero, new object[] { name, health, armour }) as IHero;
            heroes.Add(hero);

            if (type == "Knight")
                return string.Format(OutputMessages.SuccessfullyAddedKnight, name);

            return string.Format(OutputMessages.SuccessfullyAddedBarbarian, name);
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponAlreadyExists, name));
            }

            if (!weaponTypes.Contains(type))
            {
                throw new InvalidOperationException(OutputMessages.WeaponTypeIsInvalid);
            }

            Type typeOfWeapon = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);
            IWeapon weapon = Activator.CreateInstance(typeOfWeapon, new object[] { name, durability }) as IWeapon;
            weapons.Add(weapon);

            return string.Format(OutputMessages.WeaponAddedSuccessfully, type.ToLower(), name);
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in heroes.Models.OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health).ThenBy(h => h.Name))
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            Map map = new Map();
            return map.Fight(heroes.Models.Where(h => h.Weapon != null).Where(h => h.IsAlive).ToList());
        }
    }
}
