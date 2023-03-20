using System;
using System.Collections.Generic;

namespace T06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>(); //color, [item, count]

            for(int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" -> ");
                string color = data[0];
                string[] clothes = data[1].Split(',');

                if (!wardrobe.ContainsKey(color))
                    wardrobe.Add(color, new Dictionary<string, int>());

                foreach (var item in clothes)
                {
                    if (wardrobe[color].ContainsKey(item))
                        wardrobe[color][item]++;

                    else
                        wardrobe[color].Add(item, 1);
                }
            }

            string[] searchingFor = Console.ReadLine().Split();
            foreach(var (color, items) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var item in items)
                {
                    Console.Write($"* {item.Key} - {item.Value} ");

                    if (color == searchingFor[0] && item.Key == searchingFor[1])
                        Console.Write("(found!)");

                    Console.WriteLine();
                }
            }
        }
    }
}
