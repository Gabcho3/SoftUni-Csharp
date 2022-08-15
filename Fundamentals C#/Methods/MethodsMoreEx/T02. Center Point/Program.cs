using System;

namespace T02._Center_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            PrintClosestPoint(x1,y1,x2,y2);
        }

        static void PrintClosestPoint(double x1, double y1, double x2, double y2)
        {
            double distance1 = Math.Abs(x1) + Math.Abs(y1);
            double distance2 = Math.Abs(x2) + Math.Abs(y2);

            Console.WriteLine(distance1 <= distance2 ? $"({x1}, {y1})" : $"({x2}, {y2})");
        }
    }
}
