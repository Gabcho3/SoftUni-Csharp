using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int heroesToCreate = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();
            while(heroes.Count < heroesToCreate)
            { 
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                switch(type)
                {
                    case "Druid": heroes.Add(new Druid(name)); break;
                    case "Paladin": heroes.Add(new Paladin(name)); break;
                    case "Rogue": heroes.Add(new Rogue(name)); break;
                    case "Warrior": heroes.Add(new Warrior(name)); break;
                    default: Console.WriteLine("Invalid hero!"); break;
                }
            }
            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
                Console.WriteLine(hero.CastAbility());

                Console.WriteLine(heroes.Sum(x => x.Power) >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
