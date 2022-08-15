using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> race = Console.ReadLine().Split().Select(int.Parse).ToList();

            double leftSum = 0;
            double rightSum = 0;

            for(int i = 0; i < race.Count; i++)
            {
                int finishIndex = (race.Count - 1) / 2;

                if (i < finishIndex)
                {
                    leftSum += race[i];

                    if (race[i] == 0)
                        leftSum *= 0.8;
                }

                else if (i > finishIndex)
                {
                    rightSum += race[i];

                    if (race[i] == 0)
                        rightSum *= 0.8;
                }

                else //skipping finish
                    continue;
            }

            if (rightSum > leftSum)
                Console.WriteLine($"The winner is left with total time: {leftSum}");

            else
                Console.WriteLine($"The winner is right with total time: {rightSum}");
        }
    }
}
