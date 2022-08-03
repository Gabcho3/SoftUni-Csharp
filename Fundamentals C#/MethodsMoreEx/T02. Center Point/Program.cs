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
            int distance1 = 0;
            int distance2 = 0;

            double currX1 = Math.Abs(x1);
            double currY1 = Math.Abs(y1);
            double currX2 = Math.Abs(x2);
            double currY2 = Math.Abs(y2);

            while(currX1 >= 0)
            {
                distance1++;
                currX1--;
            }

            while (currY1 >= 0)
            {
                distance1++;
                currY1--;
            }

            while (currX2 >= 0)
            {
                distance2++;
                currX2--;
            }

            while (currY2 >= 0)
            {
                distance2++;
                currY2--;
            }
            
            Console.WriteLine(distance1 <= distance2 ? $"({x1}, {y1})" : $"({x2}, {y2})");
        }
    }
}
