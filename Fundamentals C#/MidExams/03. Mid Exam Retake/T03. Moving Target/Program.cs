using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split().ToArray();

            while (input[0] != "End")
            {
                string action = input[0];
                int index = int.Parse(input[1]);
                int value = int.Parse(input[2]);

                switch(action)
                {
                    case "Shoot":
                        Shoot(targets, index, value);
                        break;

                    case "Add":
                        Add(targets, index, value);
                        break;

                    case "Strike":
                        Strike(targets, index, value);
                        break;
                }

                input = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(string.Join("|", targets));
        }

        static void Shoot(List<int> targets, int index, int power)
        {
            if (index < 0 || index >= targets.Count)
                return;

            targets[index] -= power;

            if (targets[index] <= 0)
                targets.RemoveAt(index);
        }

        static void Add(List<int> targets, int index, int value)
        {
            if (index < 0 || index >= targets.Count)
            {
                Console.WriteLine("Invalid placement!");
                return;
            }

            targets.Insert(index, value);
        }

        static void Strike(List<int> targets, int index, int radius)
        {
            int range = index - radius;

            if (index < 0 || index >= targets.Count || range < 0 || range >= targets.Count)
            {
                Console.WriteLine("Strike missed!");
                return;
            }

            targets.RemoveRange(index - radius, radius * 2 + 1);
        }
    }
}
