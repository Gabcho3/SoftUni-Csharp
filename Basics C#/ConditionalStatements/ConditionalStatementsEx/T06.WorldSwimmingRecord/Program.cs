using System;

namespace T06.WorldSwimmingRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double rec = double.Parse(Console.ReadLine());
            double dis = double.Parse(Console.ReadLine());
            double sec = double.Parse(Console.ReadLine());

            double must = dis * sec;
            double m15 = Math.Floor(dis / 15) * 12.5;
            double total = must + m15;
            double result = total - rec;

            if (total < rec)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {total:F2} seconds.");
            }
            else if (total >= rec)
            {
                Console.WriteLine($"No, he failed! He was {result:F2} seconds slower.");
            }
        }
    }
}
