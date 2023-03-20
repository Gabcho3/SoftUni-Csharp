using System;
using System.Collections.Generic;

namespace T08._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int canPass = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            Queue<string> queue = new Queue<string>();

            int totalPassed = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    int currPassed = 0;
                    while (currPassed < canPass && queue.Count > 0)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        currPassed++;
                    }

                    totalPassed += currPassed;
                }
                
                else
                    queue.Enqueue(input);

                input = Console.ReadLine();
            }

            Console.WriteLine($"{totalPassed} cars passed the crossroads.");
        }
    }
}
