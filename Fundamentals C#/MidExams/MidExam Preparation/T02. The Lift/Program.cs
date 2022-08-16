using System;
using System.Linq;

namespace T02._The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int[] currState = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < currState.Length; i++)
            {

                while (currState[i] != 4 && people > 0)
                {
                    currState[i]++;
                    people--;
                }
            }

            if (currState[currState.Length - 1] == 4 && people == 0)
                Console.WriteLine(string.Join(" ", currState));

            else if (currState[currState.Length - 1] == 4 && people > 0)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine(string.Join(" ", currState));
            }

            else
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", currState));
            }

        }
    }
}
