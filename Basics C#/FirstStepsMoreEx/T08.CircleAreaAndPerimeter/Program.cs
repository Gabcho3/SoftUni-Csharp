using System;

namespace T08.CircleAreaAndPerimeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());

            double calculatedarea = r * r * Math.PI;
            double calculatedperimetrer = 2 * r * Math.PI;
            Console.WriteLine($"{calculatedarea:F2}");
            Console.WriteLine($"{calculatedperimetrer:F2}");
        }
    }
}
