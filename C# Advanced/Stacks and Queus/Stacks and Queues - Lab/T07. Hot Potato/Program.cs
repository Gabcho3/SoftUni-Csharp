using System;
using System.Collections.Generic;

namespace T07._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] players = Console.ReadLine().Split();
            Queue<string> queue = new Queue<string>(players);

            int n = int.Parse(Console.ReadLine());

            int counter = 0;

            while(queue.Count > 1)
            {
                counter++;

                string currPlayer = queue.Dequeue();

                if (counter == n)
                {
                    Console.WriteLine($"Removed {currPlayer}");
                    counter = 0;
                }

                else
                    queue.Enqueue(currPlayer);
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
