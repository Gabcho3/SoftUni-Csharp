using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int[] lifts = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int neededSum = lifts.Length * 4;

            for (int i = 0; i < lifts.Length; i++)
            {
                while (lifts[i] < 4 && people > 0)
                {
                    lifts[i]++;
                    people--;
                }

                if (people == 0)
                    break;
            }

            if (people == 0 && neededSum > lifts.Sum())
                Console.WriteLine($"The lift has empty spots!\n{string.Join(" ", lifts)}");

            else if (lifts.Sum() == neededSum && people == 0)
                Console.WriteLine(string.Join(" ", lifts));

            else
                Console.WriteLine($"There isn't enough space! {people} people in a queue!\n{string.Join(" ", lifts)}");
        }
    }
}
