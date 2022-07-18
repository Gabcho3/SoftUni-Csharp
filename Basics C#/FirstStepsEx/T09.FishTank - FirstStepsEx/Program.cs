using System;

namespace T09.FishTank___FirstStepsEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int l = int.Parse(Console.ReadLine());
            int w = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            double p = double.Parse(Console.ReadLine());
            int vl = l * w * h;
            double vll = vl / 1000.00;
            double pr = p / 100.00;
            double total = vll * (1 - pr);
            Console.WriteLine(total);

        }
    }
}
