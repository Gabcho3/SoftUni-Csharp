using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    internal abstract class BaseHero
    {
        public BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; }
        public int Power { get; }

        public virtual string CastAbility()
        {
            string heroType = this.GetType().Name;

            switch(heroType)
            {
                case "Druid":
                case "Paladin":
                    return $"{heroType} - {this.Name} healed for {this.Power}";

                case "Rogue":
                case "Warrior":
                    return $"{heroType} - {Name} hit for {Power} damage";

                default: return null;
            }
        }
    }
}
