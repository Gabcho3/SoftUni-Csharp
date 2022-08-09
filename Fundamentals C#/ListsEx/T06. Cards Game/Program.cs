using System;
using System.Linq;

namespace T06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstHand = Console.ReadLine().Split().Select(int.Parse).ToList();
            var secondHand = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                for (int i = 0; i < firstHand.Count; i++)
                {
                    if (secondHand.Sum() == 0)
                    {
                        Console.WriteLine($"First player wins! Sum: {firstHand.Sum()}");
                        return;
                    }
                    if (firstHand.Sum() == 0)
                    {
                        Console.WriteLine($"Second player wins! Sum: {secondHand.Sum()}");
                        return;
                    }

                    if (firstHand[i] > secondHand[i])
                    {
                        firstHand.Add(secondHand[i]);
                        firstHand.Add(firstHand[i]);

                        firstHand[i] = 0;
                        secondHand[i] = 0;
                    }

                    else if (firstHand[i] < secondHand[i])
                    {
                        secondHand.Add(firstHand[i]);
                        secondHand.Add(secondHand[i]);

                        firstHand[i] = 0;
                        secondHand[i] = 0;
                    }

                    else
                    {
                        firstHand[i] = 0;
                        secondHand[i] = 0;
                    }
                }
            }
        }
    }
}
