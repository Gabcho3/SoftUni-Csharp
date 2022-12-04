using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security;

namespace T03._Wild_Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var animals = new Dictionary<string, Animal>(); //name, [food,area]
            string[] command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

            while(command[0] != "EndDay")
            {
                string[] data = command[1].Split('-',StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                int food = int.Parse(data[1]);
                switch(command[0])
                {
                    case "Add":
                        string area = data[2];
                        Add(animals, name, food, area);
                        break;

                    case "Feed":
                        Feed(animals, name, food);
                        break;
                }

                command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            }

            var areas = new Dictionary<string, int>(); //area, animals
            Console.WriteLine("Animals:");
            foreach(var (animal, stats) in animals)
            {
                Console.WriteLine($" {animal} -> {stats.Food}g");

                if(!areas.ContainsKey(stats.Area))
                    areas.Add(stats.Area, 0);

                areas[stats.Area]++;
            }

            Console.WriteLine("Areas with hungry animals:");
            foreach(var (area, count) in areas)
            {
                Console.WriteLine($"{area}: {count}");
            }
        }

        private static void Feed(Dictionary<string, Animal> animals, string name, int food)
        {
            if(animals.ContainsKey(name))
            {
                animals[name].Food -= food;

                if (animals[name].Food <= 0)
                {
                    animals.Remove(name);
                    Console.WriteLine($"{name} was successfully fed");
                }
            }
        }

        private static void Add(Dictionary<string, Animal> animals, string name, int food, string area)
        {
            if(animals.ContainsKey(name))
            {
                animals[name].Food += food;
            }

            else
            {
                animals.Add(name, new Animal() { Food = food, Area = area });
            }
        }
    }

    class Animal
    {
        public int Food { get; set; }

        public string Area { get; set; }
    }
}
