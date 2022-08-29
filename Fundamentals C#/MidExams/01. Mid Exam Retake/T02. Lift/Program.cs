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
            List<int> currState = Console.ReadLine().Split().Select(int.Parse).ToList();

            for(int i = 0; i < currState.Count; i++)
            {
                while(currState[i] != 4 && people > 0)
                {
                    currState[i]++;
                    people--;
                }
            }

            //ALL OPTIONS
            if (people == 0 && currState[currState.Count - 1] < 4)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", currState));
                return;
            }

            else if (people > 0 && currState[currState.Count - 1] == 4)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine(string.Join(" ", currState));
                return;
            }

            else
            {
                Console.WriteLine(string.Join(" ", currState));
                return;
            }
        }
    }
}
