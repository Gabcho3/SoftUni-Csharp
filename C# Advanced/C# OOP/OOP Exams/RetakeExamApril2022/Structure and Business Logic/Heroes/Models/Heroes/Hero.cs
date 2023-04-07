﻿using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HeroNameNull);
                }
                name = value;
            }
        }

        public int Health
        {
            get { return health; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroHealthBelowZero);
                }
                health = value;
            }
        }

        public int Armour
        {
            get { return armour; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroArmourBelowZero);
                }
                armour = value;
            }

        }

        public IWeapon Weapon
        {
            get { return weapon; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.WeaponNull);
                }
                weapon = value;
            }
        }

        public bool IsAlive => health > 0;

        public void AddWeapon(IWeapon weapon)
        {
            Weapon = weapon;
        }

        public void TakeDamage(int points)
        {
            armour -= points;
            if (armour <= 0)
            {
                health += armour;
                armour = 0;
            }

            if(health <= 0)
                health = 0; 
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}: {Name}");
            sb.AppendLine($"--Health: {Health}");
            sb.AppendLine($"--Armour: {Armour}");
            sb.Append("--Weapon: ");
            sb.Append(Weapon != null ? Weapon.Name : "Unarmed");

            return sb.ToString().TrimEnd();
        }
    }
}
