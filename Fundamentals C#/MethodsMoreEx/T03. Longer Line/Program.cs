using System;

namespace T03._Longer_Line
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = 0;
            double y1 = 0;
            double x2 = 0;
            double y2 = 0;

            CheckLongerLine(x1, y1, x2, y2);
        }

        static void CheckLongerLine(double x1, double y1, double x2, double y2)
        {
            double bestDistance = double.MinValue;

            double bestX1 = 0;
            double bestY1 = 0;
            double bestX2 = 0;
            double bestY2 = 0;

            for (int i = 0; i < 2; i++)
            {
                x1 = double.Parse(Console.ReadLine());
                y1 = double.Parse(Console.ReadLine());
                x2 = double.Parse(Console.ReadLine());
                y2 = double.Parse(Console.ReadLine());

                double currDistance = Math.Abs(x1) + Math.Abs(y1) + Math.Abs(x2) + Math.Abs(y2);

                if(currDistance > bestDistance)
                {
                    bestDistance = currDistance;

                    bestX1 = x1;
                    bestY1 = y1;

                    bestX2 = x2;
                    bestY2 = y2;
                }
            }

            PrintLongerLine(bestX1, bestY1, bestX1, bestY2);
        }

        static void PrintLongerLine(double bestX1, double bestY1, double bestX2, double bestY2)
        {
            //Which point is closer of best coordinates
            double distance1 = Math.Abs(bestX1) + Math.Abs(bestY1); 
            double distance2 = Math.Abs(bestX2) + Math.Abs(bestY2);

            if (distance1 < distance2)
                Console.WriteLine($"({bestX1}, {bestY1})({bestX2}, {bestY2})");

            else
                Console.WriteLine($"({bestX2}, {bestY2})({bestX1}, {bestY1})");
        }
    }
}
