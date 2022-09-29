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

            List<Plant> plants = new List<Plant>();

            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);

                bool found = false;

                foreach(Plant plant in plants)
                    if(plant.Name == input[0])
                    {
                        plant.Rarity = int.Parse(input[1]);

                        found = true;
                    }

                if(!found)
                {
                    Plant plant = new Plant { Name = input[0], Rarity = double.Parse(input[1]), Ratings = new List<double>() };
                    plants.Add(plant);
                }
            }

            string[] command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Exhibition")
            {
                string[] data = command[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Rate":
                        Rate(plants, data);
                        break;

                    case "Update":
                        Update(plants, data);
                        break;

                    case "Reset":
                        Reset(plants, data);
                        break;
                }

                command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach(Plant plant in plants)
            {
                if (plant.Ratings.Count == 0)
                    plant.Ratings.Add(0);

                Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {plant.Ratings.Average():f2}");
            }
        }

        static void Rate(List<Plant> plants, string[] data)
        {
            bool found = false;

            for (int i = 0; i < plants.Count; i++)
                if (plants[i].Name == data[0])
                {
                    plants[i].Ratings.Add(double.Parse(data[1]));

                    found = true;

                    break;
                }

            if (!found)
                Console.WriteLine("error");
        }

        static void Update(List<Plant> plants, string[] data)
        {
            bool found = false;

            for (int i = 0; i < plants.Count; i++)
                if (plants[i].Name == data[0])
                {
                    plants[i].Rarity = double.Parse(data[1]);

                    found = true;

                    break;
                }

            if (!found)
                Console.WriteLine("error");
        }

        static void Reset(List<Plant> plants, string[] data)
        {
            bool found = false;

            for (int i = 0; i < plants.Count; i++)
                if (plants[i].Name == data[0])
                {
                    plants[i].Ratings = new List<double>();

                    plants[i].Ratings.Add(0);

                    found = true;

                    break;
                }

            if (!found)
                Console.WriteLine("error");
        }
    }

    class Plant
    {
        public string Name { get; set; }

        public double Rarity { get; set; }

        public List<double> Ratings { get; set; }
    }
}