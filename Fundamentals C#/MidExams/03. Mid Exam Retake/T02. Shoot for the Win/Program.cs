using System;
using System.Linq;

namespace T02._Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();

            int shots = 0;

            while(input != "End")
            {
                int index = int.Parse(input);

                if(index < 0 || index >= targets.Length)
                {
                    input = Console.ReadLine();
                    continue;
                }

                for(int i = 0; i < targets.Length; i++)
                {
                    if (targets[i] == -1 || i == index)
                        continue;

                    if (targets[i] > targets[index])
                        targets[i] -= targets[index];

                    else
                        targets[i] += targets[index];
                }

                targets[index] = -1;
                shots++;

                input = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {shots} -> {string.Join(" ", targets)}");
        }
    }
}
