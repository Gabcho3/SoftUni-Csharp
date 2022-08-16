using System;

namespace T01._Black_Flag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int daylyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double plunderGained = 0;

            for(int day = 1; day <= days; day++)
            {
                plunderGained += daylyPlunder;

                if (day % 3 == 0)
                    plunderGained += daylyPlunder * 0.5;

                if (day % 5 == 0)
                    plunderGained *= 0.7;
            }

            if (plunderGained >= expectedPlunder)
                Console.WriteLine($"Ahoy! {plunderGained:f2} plunder gained.");

            else
                Console.WriteLine($"Collected only {plunderGained / expectedPlunder * 100:f2}% of the plunder.");
        }
    }
}
