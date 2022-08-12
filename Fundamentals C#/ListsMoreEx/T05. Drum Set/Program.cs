using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Drum_Set
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            List<int> initialDrumSet = new List<int>();
            for (int i = 0; i < drumSet.Count; i++)
            {
                initialDrumSet.Add(drumSet[i]);
            }

            while(command != "Hit it again, Gabsy!")
            {
                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= int.Parse(command);

                    if (drumSet[i] <= 0)
                    {
                        if (savings >= initialDrumSet[i] * 3)
                        {
                            savings -= initialDrumSet[i] * 3;
                            drumSet.RemoveAt(i);
                            drumSet.Insert(i, initialDrumSet[i]);
                        }

                        else
                        {
                            drumSet.RemoveAt(i);
                            initialDrumSet.RemoveAt(i);
                            i--;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
