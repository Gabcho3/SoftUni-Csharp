using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> coffeine = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> drinks = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int limit = 300;
            int mgDrank = 0;

            while (true)
            {
                int sum = coffeine.Pop() * drinks.Peek();

                if (sum < limit && mgDrank < 300)
                {
                    mgDrank += sum;
                    limit -= sum;
                    drinks.Dequeue();
                }

                else
                {
                    int currDrink = drinks.Dequeue();
                    drinks.Enqueue(currDrink);

                    if (mgDrank >= 30)
                    {
                        mgDrank -= 30;
                    }
                    limit += 30;
                }

                if (drinks.Count == 0)
                {
                    Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
                    break;
                }

                if (coffeine.Count == 0)
                {
                    Console.WriteLine($"Drinks left: {string.Join(", ", drinks)}");
                    break;
                }
            }
            Console.WriteLine($"Stamat is going to sleep with {mgDrank} mg caffeine.");
        }
    }
}
