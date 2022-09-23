using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace T05._Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string health = @"[^+\-*\/.\d]";
            string damage = @"[+-]?\d+[.]?\d*";
            string signs = @"[\/*]";

            string input = Console.ReadLine();
            string rexexInput = @"[,\s]+";
            string[] demonsNames = Regex.Split(input, rexexInput);

            var demons = new SortedDictionary<string, List<Demon>>();

            for(int i = 0; i < demonsNames.Length; i++)
            {
                var healthMatch = Regex.Matches(demonsNames[i], health);
                var damageMatch = Regex.Matches(demonsNames[i], damage);
                var signMatch = Regex.Matches(demonsNames[i], signs);

                double healthSum = 0;
                double damageSum = 0;

                foreach (Match match in healthMatch)
                    healthSum += char.Parse(match.ToString());

                foreach (Match match in damageMatch)
                    damageSum += double.Parse(match.ToString());

                foreach(Match match in signMatch)
                {
                    if (match.ToString() == "*")
                        damageSum *= 2;

                    else
                        damageSum /= 2;
                }

                Demon demon = new Demon { Health = healthSum, Damage = damageSum };

                demons[demonsNames[i]] = new List<Demon>();
                demons[demonsNames[i]].Add(demon);
            }

            foreach (var demon in demons)
                foreach (var sum in demons[demon.Key])
                    Console.WriteLine($"{demon.Key} - {sum.Health} health, {sum.Damage:f2} damage");
        }

        class Demon
        {
            public double Health { get; set; }

            public double Damage { get; set; }
        }
    }
}
