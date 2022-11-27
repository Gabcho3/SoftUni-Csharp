using System;
using System.Collections.Generic;

namespace Т03._P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var towns = new Dictionary<string, Town>();
            string[] input = Console.ReadLine().Split("||");

            while (input[0] != "Sail")
            {
                string name = input[0];
                int population = int.Parse(input[1]);
                int gold = int.Parse(input[2]);

                if (towns.ContainsKey(name))
                {
                    towns[name].Population += population;
                    towns[name].Gold += gold;
                }

                else
                {
                    towns.Add(name, new Town() { Population = population, Gold = gold });
                }

                input = Console.ReadLine().Split("||");
            }

            input = Console.ReadLine().Split("=>");

            while (input[0] != "End")
            {
                string name = input[1];

                switch (input[0])
                {
                    case "Plunder":
                        int population = int.Parse(input[2]);
                        int gold = int.Parse(input[3]);
                        Plunder(towns, name, population, gold);
                        break;

                    case "Prosper":
                        gold = int.Parse(input[2]);
                        Prosper(towns, name, gold);
                        break;
                }

                input = Console.ReadLine().Split("=>");
            }

            if (towns.Count == 0)
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");

            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");
                foreach (var (town, stats) in towns)
                    Console.WriteLine($"{town} -> Population: {stats.Population} citizens, Gold: {stats.Gold} kg");
            }
        }

        private static void Prosper(Dictionary<string, Town> towns, string name, int gold)
        {
            if (gold < 0)
            {
                Console.WriteLine("Gold added cannot be a negative number!");
                return;
            }

            towns[name].Gold += gold;
            Console.WriteLine($"{gold} gold added to the city treasury. {name} now has {towns[name].Gold} gold.");
        }

        private static void Plunder(Dictionary<string, Town> towns, string name, int population, int gold)
        {
            towns[name].Population -= population;
            towns[name].Gold -= gold;
            Console.WriteLine($"{name} plundered! {gold} gold stolen, {population} citizens killed.");
            if (towns[name].Population == 0 || towns[name].Gold == 0)
            {
                Console.WriteLine($"{name} has been wiped off the map!");
                towns.Remove(name);
            }
        }
    }

    class Town
    {
        public int Population { get; set; }

        public int Gold { get; set; }
    }
}