using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sequence = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string[] command = Console.ReadLine().Split();

            int turns = 0;

            while (command[0] != "end")
            {
                int index1 = int.Parse(command[0]);
                int index2 = int.Parse(command[1]);

                bool cheat = index1 == index2
                    || index1 < 0
                    || index2 < 0
                    || index1 >= sequence.Count
                    || index2 >= sequence.Count
                    ? true : false;

                turns++;

                if (cheat)
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    sequence.Insert(sequence.Count / 2, $"-{turns}a");
                    sequence.Insert(sequence.Count / 2, $"-{turns}a");
                }

                else
                {
                    if (sequence[index1] == sequence[index2])
                    {
                        string element = sequence[index1];
                        Console.WriteLine($"Congrats! You have found matching elements - {element}!");
                        sequence.RemoveAll(e => e == element);
                    }

                    else
                        Console.WriteLine("Try again!");

                    if (sequence.Count == 0)
                    {
                        Console.WriteLine($"You have won in {turns} turns!");
                        return;
                    }
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"Sorry you lose :(\n{string.Join(" ", sequence)}");
        }
    }
}
