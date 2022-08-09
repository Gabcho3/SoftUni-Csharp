using System;
using System.Collections.Generic;
using System.Linq;

namespace T01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "end")
            {
                switch(command[0])
                {
                    case "Add":
                        wagons.Add(int.Parse(command[1]));
                        break;
                    default:
                        AddPassengersToWagon(wagons, maxCapacity, command);
                        break;
                }
                command = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }

        static void AddPassengersToWagon(List<int> wagons, int maxCapacity, string[] command)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                int currPasengers = wagons[i] + int.Parse(command[0]);

                if (currPasengers <= maxCapacity)
                {
                    wagons[i] = currPasengers;
                    break;
                }
            }
        }
    }
}
