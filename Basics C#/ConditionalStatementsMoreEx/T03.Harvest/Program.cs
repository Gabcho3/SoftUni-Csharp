using System;

namespace T03.Harvest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int X = int.Parse(Console.ReadLine()); //кв.м лозе
            double Y = double.Parse(Console.ReadLine()); //кг грозде за 1 кв.м
            int Z = int.Parse(Console.ReadLine());//литри вино
            int workers = int.Parse(Console.ReadLine());

            double grape = X * Y;
            double wine = grape * 0.40 / 2.5;

            if (wine >= Z)
            {
                double rest = wine - Z;
                double forWorker = rest / workers;
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wine)} liters.");
                Console.WriteLine($"{Math.Ceiling(rest)} liters left -> {Math.Ceiling(forWorker)} liters per person.");
            }
            else
            {
                double rest = Z - wine;
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(rest)} liters wine needed.");
            }
        }
    }
}
