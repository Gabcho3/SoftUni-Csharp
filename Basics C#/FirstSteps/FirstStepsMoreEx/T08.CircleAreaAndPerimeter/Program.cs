using System;

namespace T08.CircleAreaAndPerimeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());

            double calculatedArea = r * r * Math.PI;
            double calculatedPerimetrer = 2 * r * Math.PI;
            Console.WriteLine($"{calculatedArea:F2}");
            Console.WriteLine($"{calculatedPerimetrer:F2}");
        }
    }
}
