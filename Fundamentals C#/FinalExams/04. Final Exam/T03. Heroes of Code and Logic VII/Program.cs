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
            var heroes = new Dictionary<string, Hero>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                int hp = int.Parse(data[1]);
                int mp = int.Parse(data[2]);

                hp = hp > 100 ? 100 : hp;
                mp = mp > 200 ? 200 : mp;

                heroes.Add(name, new Hero() { HP = hp, MP = mp });
            }

            string[] command = Console.ReadLine().Split(" - ");
            while (command[0] != "End")
            {
                string heroName = command[1];
                switch (command[0])
                {
                    case "CastSpell":
                        int mpNeed = int.Parse(command[2]);
                        string spellName = command[3];
                        CastSpell(heroes, heroName, mpNeed, spellName);
                        break;

                    case "TakeDamage":
                        int damage = int.Parse(command[2]);
                        string attacker = command[3];
                        TakeDamage(heroes, heroName, damage, attacker);
                        break;

                    case "Recharge":
                        int amount = int.Parse(command[2]);
                        Recharge(heroes, heroName, amount);
                        break;

                    case "Heal":
                        amount = int.Parse(command[2]);
                        Heal(heroes, heroName, amount);
                        break;
                }

                command = Console.ReadLine().Split(" - ");
            }

            foreach (var (hero, stats) in heroes)
                Console.WriteLine($"{hero}\n  HP: {stats.HP}\n  MP: {stats.MP}");
        }

        private static void Heal(Dictionary<string, Hero> heroes, string heroName, int amount)
        {
            int firstHp = heroes[heroName].HP;
            heroes[heroName].HP += amount;
            int recovered;
            if (heroes[heroName].HP > 100)
            {
                recovered = 100 - firstHp;
                heroes[heroName].HP = 100;
            }

            else
                recovered = amount;

            Console.WriteLine($"{heroName} healed for {recovered} HP!");
        }

        private static void Recharge(Dictionary<string, Hero> heroes, string heroName, int amount)
        {
            int firstMp = heroes[heroName].MP;
            heroes[heroName].MP += amount;
            int recovered;
            if (heroes[heroName].MP > 200)
            {
                recovered = 200 - firstMp;
                heroes[heroName].MP = 200;
            }

            else
                recovered = amount;

            Console.WriteLine($"{heroName} recharged for {recovered} MP!");
        }

        private static void TakeDamage(Dictionary<string, Hero> heroes, string heroName, int damage, string attacker)
        {
            heroes[heroName].HP -= damage;
            if (heroes[heroName].HP > 0)
                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HP} HP left!");

            else
            {
                Console.WriteLine($"{heroName} has been killed by {attacker}!");
                heroes.Remove(heroName);
            }
        }

        private static void CastSpell(Dictionary<string, Hero> heroes, string heroName, int mpNeed, string spellName)
        {
            if (heroes[heroName].MP >= mpNeed)
            {
                heroes[heroName].MP -= mpNeed;
                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].MP} MP!");
            }

            else
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
        }
    }

    class Hero
    {
        public int HP { get; set; }

        public int MP { get; set; }
    }
}
