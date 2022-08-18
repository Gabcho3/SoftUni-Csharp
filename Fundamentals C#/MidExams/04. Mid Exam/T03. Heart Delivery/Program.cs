using System;
using System.Linq;

namespace T03._Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine().Split("@").Select(int.Parse).ToArray();
            string[] jump = Console.ReadLine().Split();

            int length = 0;
            int lastPosition = 0;

            while (jump[0] != "Love!")
            {
                length += int.Parse(jump[1]);

                for(int i = 0; i < houses.Length; i++)
                {
                    if (length >= houses.Length)
                        length = 0;

                    if (i == length)
                    {
                        lastPosition = i;

                        if (houses[i] == 0)
                        {
                            Console.WriteLine($"Place {i} already had Valentine's day.");
                            break;
                        }

                        houses[i] -= 2;

                        if (houses[i] <= 0)
                            Console.WriteLine($"Place {i} has Valentine's day.");

                        break; //we already jumped {need new jump}
                    }
                }
                jump = Console.ReadLine().Split();
            }

            Console.WriteLine($"Cupid's last position was {lastPosition}.");

            IsSuccessful(houses);
        }

        static void IsSuccessful(int[] houses)
        {
            bool successful = true;
            int count = 0;

            foreach (int hearts in houses)
            {
                if (hearts > 0)
                {
                    successful = false;
                    count++;
                }
            }

            if (successful)
                Console.WriteLine("Mission was successful.");

            else
                Console.WriteLine($"Cupid has failed {count} places.");
        }
    }
}
