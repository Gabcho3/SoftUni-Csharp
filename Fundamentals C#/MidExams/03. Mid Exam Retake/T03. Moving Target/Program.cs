using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split().ToArray();

                if (command[0] == "End")
                {
                    Console.WriteLine(string.Join('|', targets));

                    return;
                }

                int index = int.Parse(command[1]);
                int value = int.Parse(command[2]);
                bool valid = index >= 0 && index < targets.Count;

                switch (command[0])
                {
                    case "Shoot":
                        if (valid)
                            Shoot(targets, index, value);
                        break;

                    case "Add":
                        if (valid)
                            Add(targets, index, value);

                        else
                            Console.WriteLine("Invalid placement!");
                        break;

                    case "Strike":
                        if (valid)
                            Strike(targets, index, value);

                        else
                            Console.WriteLine("Strike missed!");
                        break;
                }
            }
        }

        static void Shoot(List<int> targets, int index, int power)
        {
            targets[index] -= power;

            if (targets[index] <= 0)
                targets.RemoveAt(index);
        }

        static void Add(List<int> targets, int index, int value)
        {
            targets.Insert(index, value);
        }

        static void Strike(List<int> targets, int index, int radius)
        {
            int count = 2 * radius + 1;

            if (index + radius >= targets.Count || index - radius < 0)
            {
                Console.WriteLine("Strike missed!");
                return;
            }

            targets.RemoveRange(index - radius, count);
        }
    }
}
