using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.EnergyDrinks
{
    internal class Program
    {
        public const int maxCaffeine = 300;
        static void Main(string[] args)
        {
            int initial = 0;

            Stack<int> miligrams = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> drinks = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            while (true)
            {
                int currCaffeine = miligrams.Pop() * drinks.Peek();

                if (currCaffeine + initial <= maxCaffeine)
                {
                    initial += currCaffeine;
                    drinks.Dequeue();
                }

                else
                {
                    drinks.Enqueue(drinks.Dequeue());

                    initial = initial - 30 > 0 ? initial - 30 : 0;
                }

                if (miligrams.Count == 0 || drinks.Count == 0)
                {
                    break;
                }
            }

            string output = drinks.Count > 0 ? $"Drinks left: {string.Join(", ", drinks)}"
                : "At least Stamat wasn't exceeding the maximum caffeine.";
            Console.WriteLine(output);
            Console.WriteLine($"Stamat is going to sleep with {initial} mg caffeine.");
        }
    }
}
