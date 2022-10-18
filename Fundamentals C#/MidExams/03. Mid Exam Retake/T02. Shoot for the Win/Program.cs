using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace T02._Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();

            int count = 0;

            while(input != "End")
            {
                int index = int.Parse(input);

                bool valid = index >= 0 && index < targets.Length && targets[index] != -1 ? true : false;

                if (valid)
                {
                    int currTarger = targets[index];

                    for(int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i] == -1 || i == index)
                            continue;

                        if (targets[i] > currTarger)
                            targets[i] -= currTarger;

                        else
                            targets[i] += currTarger;
                    }

                    targets[index] = -1;

                    count++;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {count} -> {string.Join(" ", targets)}");
        }
    }
}
