using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Intrinsics.X86;

namespace T01.BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cofeeQuantities = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> milkQuantities = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            List<string[]> drinks = new List<string[]>()
            {
                new string[2] { "Cortado", "50" },
                new string[2] { "Espresso", "75" },
                new string[2] { "Capuccino", "100" },
                new string[2] { "Americano", "150" },
                new string[2] { "Latte", "200" },
            };

            Dictionary<string, int> beverages = new Dictionary<string, int>();

            while (cofeeQuantities.Count > 0 && milkQuantities.Count > 0)
            {
                int sum = cofeeQuantities.Dequeue() + milkQuantities.Peek();

                if (drinks.Any(x => int.Parse(x[1]) == sum))
                {
                    milkQuantities.Pop();
                    string drink = drinks.Find(x => int.Parse(x[1]) == sum)[0];

                    if(!beverages.ContainsKey(drink))
                    {
                        beverages.Add(drink, 0);
                    }
                    beverages[drink]++;
                }

                else
                {
                    milkQuantities.Push(milkQuantities.Pop() - 5);
                }
            }

            if(cofeeQuantities.Count == 0 && milkQuantities.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }

            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            Console.WriteLine(cofeeQuantities.Count > 0 ? $"Coffee left: {string.Join(", ", cofeeQuantities)}" : "Cofee left: none");
            Console.WriteLine(milkQuantities.Count > 0 ? $"Milk left: {string.Join(", ", milkQuantities)}" : "Milk left: none");

            foreach(var (drink, ammount) in beverages.OrderBy(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(drink + ": " + ammount);
            }
        }
    }
}
