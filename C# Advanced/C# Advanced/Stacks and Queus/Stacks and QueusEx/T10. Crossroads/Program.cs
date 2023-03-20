using System;
using System.Collections.Generic;

namespace T10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLineSec = int.Parse(Console.ReadLine());
            int freeWindowSec = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            Queue<string> queue = new Queue<string>();
            int totalCars = 0;

            while (input != "END")
            {
                if(input != "green")
                    queue.Enqueue(input);

                else
                {
                    int currGreenLineSec = greenLineSec;

                    while(queue.Count > 0 && currGreenLineSec > 0)
                    {
                        int carValue = queue.Peek().Length;
                        totalCars++;

                        if (currGreenLineSec >= carValue)
                            currGreenLineSec -= carValue;

                        else 
                        {
                            carValue -= currGreenLineSec;
                            currGreenLineSec = 0;

                            if(carValue > freeWindowSec)
                            {
                                int index = queue.Peek().Length - (carValue - freeWindowSec);
                                Console.WriteLine($"A crash happened!\n{queue.Peek()} was hit at {queue.Peek()[index]}.");

                                return;
                            }
                        }

                        queue.Dequeue();
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Everyone is safe.\n{totalCars} total cars passed the crossroads.");
        }
    }
}
