using System;
using System.Collections.Generic;
using System.Linq;

namespace Т03._P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("||");

            List<City> cities = new List<City>();

            while (input[0] != "Sail")
            {
                City city = new City() 
                { 
                    Name = input[0],
                    Population = int.Parse(input[1]),
                    Gold = int.Parse(input[2]) 
                };

                if (cities.Any(c => c.Name == city.Name))
                {
                    for (int i = 0; i < cities.Count; i++)
                    {
                        if (city.Name == cities[i].Name)
                        {
                            cities[i].Population += city.Population;
                            cities[i].Gold += city.Gold;
                        }
                    }
                }

                else
                    cities.Add(city);

                input = Console.ReadLine().Split("||");
            }

            input = Console.ReadLine().Split("=>");

            while (input[0] != "End")
            {
                string town = input[1];

                for (int i = 0; i < cities.Count; i++)
                {
                    if (cities[i].Name == town)
                    {
                        if (input[0] == "Plunder")
                        {
                            cities[i].Population -= int.Parse(input[2]);
                            cities[i].Gold -= int.Parse(input[3]);

                            Console.WriteLine($"{town} plundered! {int.Parse(input[3])} gold stolen, {int.Parse(input[2])} citizens killed.");

                            if (cities[i].Population == 0 || cities[i].Gold == 0)
                            {
                                cities.RemoveAt(i);

                                Console.WriteLine($"{town} has been wiped off the map!");
                            }
                        }

                        else
                        {
                            int gold = int.Parse(input[2]);

                            if (gold > 0)
                            {
                                cities[i].Gold += gold;

                                Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[i].Gold} gold.");
                            }

                            else
                                Console.WriteLine("Gold added cannot be a negative number!");
                        }
                    }
                }

                input = Console.ReadLine().Split("=>");
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (var town in cities)
                    Console.WriteLine($"{town.Name} -> Population: {town.Population} citizens, Gold: {town.Gold} kg");
            }

            else
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
        }

        class City
        {
            public string Name { get; set; }

            public int Population { get; set; }

            public int Gold { get; set; }
        }
    }
}
