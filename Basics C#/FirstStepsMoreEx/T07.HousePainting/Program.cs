using System;

namespace T07.HousePainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            //walls:
            double wall1 = x * y;
            double window = 1.5 * 1.5;
            double tot1 = 2 * (wall1 - window);
            double wall2 = x * x;
            double entry = 1.2 * 2;
            double tot2 = 2 * wall2 - entry;
            double walls = tot1 + tot2;
            double green = walls / 3.4;
            Console.WriteLine($"{green:F2}");
            //roof:
            double roof1 = 2 * (x * y);
            double roof2 = 2 * ((x * h) / 2);
            double roof = roof1 + roof2;
            double red = roof / 4.3;
            Console.WriteLine($"{red:F2}");
        }
    }
}
