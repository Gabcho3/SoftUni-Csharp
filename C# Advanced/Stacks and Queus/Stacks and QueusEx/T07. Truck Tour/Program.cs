using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<Pumps> pumps = new Queue<Pumps>();

            for (int i = 0; i < n; i++)
            {
                int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();

                Pumps pump = new Pumps() { Amount = data[0], Distance = data[1] };

                pumps.Enqueue(pump);
            }

            int index = -1;
            while (true)
            {
                int currAmount = 0;
                bool valid = true;

                index++;

                //Checking all circle options
                for (int i = 0; i < pumps.Count; i++)
                {
                    Pumps currPump = pumps.Dequeue();

                    currAmount += currPump.Amount;
                    currAmount -= currPump.Distance;

                    pumps.Enqueue(currPump);

                    if (currAmount < 0)
                    {
                        valid = false;
                    }
                }

                if (valid)
                {
                    Console.WriteLine(index);
                    return;
                }

                pumps.Enqueue(pumps.Dequeue());
            }
        }
    }

    class Pumps
    {
        public int Amount { get; set; }

        public int Distance { get; set; }
    }
}
