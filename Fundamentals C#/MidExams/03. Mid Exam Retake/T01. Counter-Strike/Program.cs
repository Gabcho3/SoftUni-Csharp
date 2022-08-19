using System;

namespace T01._Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int wins = 0;

            while(input != "End of battle")
            {
                int distance = int.Parse(input);

                if (energy - distance >= 0)
                {
                    energy -= distance;
                    wins++;

                    if (wins % 3 == 0)
                        energy += wins;
                }

                else
                {
                    Console.WriteLine($"Not enough energy! " +
                         $"Game ends with {wins} won battles and {energy} energy");

                    return;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {wins}. Energy left: {energy}");
        }
    }
}
