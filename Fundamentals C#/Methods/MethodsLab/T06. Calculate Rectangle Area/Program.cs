using System;

namespace T06._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double area = SumRectangelArea(width, length);
            Console.WriteLine(area);
        }

        static double SumRectangelArea(double width, double length)
        {
            return width * length;
        }
    }
}
