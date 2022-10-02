using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Hero> heroes = new List<Hero>();

            for(int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                Hero hero = new Hero { Name = data[0], Hp = int.Parse(data[1]), Mp = int.Parse(data[2]) };

                if (hero.Hp > 100)
                    hero.Hp = 100;

                if (hero.Mp > 200)
                    hero.Mp = 200;

                heroes.Add(hero);
            }

            string[] command = Console.ReadLine().Split(" - ");

            while (command[0] != "End")
            {
                string heroName = command[1];

                switch(command[0])
                {
                    case "CastSpell":
                        heroes = CastSpell(heroes, command, heroName);
                        break;

                    case "TakeDamage":
                        heroes = TakeDamage(heroes, command, heroName);
                        break;

                    case "Recharge":
                        heroes = Recharge(heroes, command, heroName);
                        break;

                    case "Heal":
                        heroes = Heal(heroes, command, heroName);
                        break;
                }

                command = Console.ReadLine().Split(" - ");
            }

            foreach(var hero in heroes)
            {
                Console.WriteLine(hero.Name);
                Console.WriteLine("  HP: " + hero.Hp);
                Console.WriteLine("  MP: " + hero.Mp);
            }
        }

        static List<Hero> CastSpell(List<Hero> heroes, string[] command, string heroName)
        {
            int mpNeed = int.Parse(command[2]);
            string spell = command[3];

            for(int i = 0; i < heroes.Count; i++)
            {
                if (heroes[i].Name == heroName)
                {
                    if (heroes[i].Mp >= mpNeed)
                    {
                        heroes[i].Mp -= mpNeed;

                        Console.WriteLine($"{heroName} has successfully cast {spell} and now has {heroes[i].Mp} MP!");
                    }

                    else
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spell}!");
                }
            }

            return heroes;
        }

        static List<Hero> TakeDamage(List<Hero> heroes, string[] command, string heroName)
        {
            int damage = int.Parse(command[2]);
            string attacker = command[3];

            for (int i = 0; i < heroes.Count; i++)
            {
                if (heroes[i].Name == heroName)
                {
                    heroes[i].Hp -= damage;

                    if (heroes[i].Hp > 0)
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[i].Hp} HP left!");

                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroes.RemoveAt(i);
                    }
                }
            }

            return heroes;
        }

        static List<Hero> Recharge(List<Hero> heroes, string[] command, string heroName)
        {
            int amount = int.Parse(command[2]);

            for (int i = 0; i < heroes.Count; i++)
            {
                if (heroes[i].Name == heroName)
                {
                    int rechared = 0;

                    while (heroes[i].Mp < 200 && rechared < amount)
                    {
                        heroes[i].Mp++;
                        rechared++;
                    }

                    Console.WriteLine($"{heroName} recharged for {rechared} MP!");
                }
            }

            return heroes;
        }

        static List<Hero> Heal(List<Hero> heroes, string[] command, string heroName)
        {
            int amount = int.Parse(command[2]);

            for (int i = 0; i < heroes.Count; i++)
            {
                if (heroes[i].Name == heroName)
                {
                    int healed = 0;

                    while(heroes[i].Hp < 100 && healed < amount)
                    {
                        heroes[i].Hp++;
                        healed++;
                    }

                    Console.WriteLine($"{heroName} healed for {healed} HP!");
                }
            }

            return heroes;
        }
    }

    class Hero
    {
        public string Name { get; set; }

        public int Hp { get; set; }

        public int Mp { get; set; }
    }
        
}
