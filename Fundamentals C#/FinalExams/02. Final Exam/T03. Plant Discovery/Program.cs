using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var plants = new Dictionary<string, Plant>(); //Name, Rarity && Rating

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split("<->");

                string name = data[0];
                int rarity = int.Parse(data[1]);

                Plant plant = new Plant() { Rarity = rarity, Rating = new List<int>() };

                plants[name] = plant;
            }

            string[] command = Console.ReadLine().Split(':');

            while (command[0] != "Exhibition")
            {
                string[] data = command[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string plantName = data[0].Remove(0, 1);

                if (!plants.ContainsKey(plantName))
                    Console.WriteLine("error");

                else
                {
                    switch (command[0])
                    {
                        case "Rate":
                            int rating = int.Parse(data[1]);
                            plants[plantName].Rating.Add(rating);
                            break;

                        case "Update":
                            int rarity = int.Parse(data[1]);
                            plants[plantName].Rarity = rarity;
                            break;

                        case "Reset":
                            plants[plantName].Rating = new List<int>();
                            break;
                    }
                }

                command = Console.ReadLine().Split(':');
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in plants)
            {
                double averageRating = 0;

                if (plant.Value.Rating.Count > 0)
                    averageRating = plant.Value.Rating.Average();

                Console.WriteLine($"- {plant.Key}; " +
                                  $"Rarity: {plant.Value.Rarity}; " +
                                  $"Rating: {averageRating:f2}");
            }

        }
    }

    class Plant
    {
        public int Rarity { get; set; }

        public List<int> Rating { get; set; }
    }
}