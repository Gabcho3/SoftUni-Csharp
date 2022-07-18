using System;

namespace T06.Repainting___FirstStepsEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ny = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int t = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            double priceny = (ny + 2) * 1.50;
            double pricep = (p + (p * 0.10)) * 14.50;
            double pricet = t * 5.00;
            double bag = 0.40;
            double sump = (priceny + pricep + pricet + bag) * 0.30;
            double sumptot = sump * h;
            double total = sumptot + priceny + pricep + pricet + bag;
            Console.WriteLine(total);
        }
    }
}
