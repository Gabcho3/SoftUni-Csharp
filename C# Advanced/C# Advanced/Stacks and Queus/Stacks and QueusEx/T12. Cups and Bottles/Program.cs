using System;
using System.Collections.Generic;
using System.Linq;

namespace T12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> cups = new List<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int wasted = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currBottle = bottles.Peek();

                if (currBottle >= cups[0])
                {
                    wasted += bottles.Pop() - cups[0];
                    cups.RemoveAt(0);
                }

                else
                {
                    cups[0] -= bottles.Pop();

                    if (cups[0] <= 0)
                        cups.RemoveAt(0);
                }
            }

            if (cups.Count == 0)
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");

            if (bottles.Count == 0)
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");

            Console.WriteLine($"Wasted litters of water: {wasted}");
        }
    }
}
