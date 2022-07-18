using System;

namespace T06.FlowerShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mg = int.Parse(Console.ReadLine());
            int zm = int.Parse(Console.ReadLine());
            int rose = int.Parse(Console.ReadLine());
            int ca = int.Parse(Console.ReadLine());
            double sur = double.Parse(Console.ReadLine());

            double sum = mg * 3.25 + zm * 4.00 + rose * 3.50 + ca * 8.00;
            double da = sum * 0.05;
            double profit = sum - da;

            if (profit >= sur)
            {
                double rest = profit - sur;
                Console.WriteLine($"She is left with {Math.Floor(rest)} leva.");
            }
            else
            {
                double rest = sur - profit;
                Console.WriteLine($"She will have to borrow {Math.Ceiling(rest)} leva.");
            }
        }
    }
}
