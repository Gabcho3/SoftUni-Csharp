using System;
using System.Collections.Generic;

namespace T06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            Queue<string> queue = new Queue<string>(songs);

            while (queue.Count > 0)
            {
                string command = Console.ReadLine();

                switch (command[0])
                {
                    case 'P':
                        queue.Dequeue();
                        break;

                    case 'A':
                        string song = command.Substring(4, command.Length - 4);
                        if (queue.Contains(song))
                            Console.WriteLine(song + " is already contained!");

                        else
                            queue.Enqueue(song);
                        break;

                    case 'S':
                        Console.WriteLine(string.Join(", ", queue));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
