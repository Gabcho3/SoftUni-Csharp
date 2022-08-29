using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> sequence = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] input = Console.ReadLine().Split().ToArray();

            int turns = 0;

            while (input[0] != "end")
            {
                turns++;

                int index1 = int.Parse(input[0]);
                int index2 = int.Parse(input[1]);

                if(index1 == index2 || index1 < 0 || index1 >= sequence.Count || 
                   index2 < 0 || index2 >= sequence.Count)
                {
                    sequence.Insert(sequence.Count / 2, $"-{turns}a");
                    sequence.Insert(sequence.Count / 2, $"-{turns}a");

                    Console.WriteLine("Invalid input! Adding additional elements to the board");

                    input = Console.ReadLine().Split().ToArray();
                    continue;
                }

                if (sequence[index1] == sequence[index2])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {sequence[index1]}!");

                    if(index1 < index2)
                    {
                        sequence.RemoveAt(index1);
                        sequence.RemoveAt(index2 - 1);
                    }

                    else
                    {
                        sequence.RemoveAt(index2);
                        sequence.RemoveAt(index1 - 1);
                    }
                }

                else
                    Console.WriteLine("Try again!");

                if(sequence.Count == 0)
                {
                    Console.WriteLine($"You have won in {turns} turns!");
                    return;
                }

                input = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
