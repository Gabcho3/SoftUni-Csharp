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
            Stack<int> botlles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int wasted = 0;

            while (cups.Count > 0 && botlles.Count > 0)
            {
                int currBotlle = botlles.Peek();

                if (currBotlle >= cups[0])
                {
                    wasted += botlles.Pop() - cups[0];
                    cups.RemoveAt(0);
                }

                else
                {
                    cups[0] -= botlles.Pop();

                    if (cups[0] <= 0)
                        cups.RemoveAt(0);
                }
            }

            if (cups.Count == 0)
                Console.WriteLine($"Botlles: {string.Join(" ", botlles)}");

            if (botlles.Count == 0)
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");

            Console.WriteLine($"Wasted litters of water: {wasted}");
        }
    }
}
