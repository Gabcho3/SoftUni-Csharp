using System;

namespace T05.Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bj = double.Parse(Console.ReadLine());
            string se = Console.ReadLine();

            if (bj <= 100)
            {
                if (se == "summer")
                {
                    Console.WriteLine("Somewhere in Bulgaria"); Console.WriteLine($"Camp - {bj * 0.30:F2}");

                }
                if (se == "winter")
                {
                    Console.WriteLine("Somewhere in Bulgaria"); Console.WriteLine($"Hotel - { bj * 0.70:F2}");
                }
            }

            if (bj > 100 && bj <= 1000)
            {
                if (se == "summer")
                {
                    Console.WriteLine("Somewhere in Balkans"); Console.WriteLine($"Camp - {bj * 0.40:F2}");

                }
                if (se == "winter")
                {
                    Console.WriteLine("Somewhere in Balkans"); Console.WriteLine($"Hotel - { bj * 0.80:F2}");
                }

            }


            if (bj > 1000)
            {
                Console.WriteLine($"Somewhere in Europe"); Console.WriteLine($"Hotel - {bj * 0.90:F2}");
            }
        }
    }
}
