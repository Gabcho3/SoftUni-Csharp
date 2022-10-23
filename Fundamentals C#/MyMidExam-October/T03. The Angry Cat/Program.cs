using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._The_Angry_Cat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> priceRatings = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            int entryPoint = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();

            int entryPrice = priceRatings[entryPoint];

            int leftSum = 0;
            int rightSum = 0;

            if(type == "cheap")
            {
                for (int i = 0; i < entryPoint; i++)
                {
                    if (priceRatings[i] < entryPrice)
                        leftSum += priceRatings[i];
                }

                for (int i = entryPoint; i < priceRatings.Count; i++)
                {
                    if (priceRatings[i] < entryPrice)
                        rightSum += priceRatings[i];
                }

                if (rightSum > leftSum)
                    Console.WriteLine($"Right - {rightSum}");
                else if (leftSum >= rightSum)
                    Console.WriteLine($"Left - {leftSum}");
            }

            else
            {
                for(int i = 0; i < entryPoint; i++)
                {
                    if (priceRatings[i] >= entryPrice)
                        leftSum += priceRatings[i];
                }

                for (int i = entryPoint + 1; i < priceRatings.Count; i++)
                {
                    if (priceRatings[i] >= entryPrice)
                        rightSum += priceRatings[i];
                }

                if (leftSum < rightSum)
                    Console.WriteLine($"Right - {rightSum}");

                else if (leftSum >= rightSum )
                    Console.WriteLine($"Left - {leftSum}");
            }
        }
    }
}
