using System;

namespace T05.DivisionWithoutRemainder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double n = int.Parse(Console.ReadLine());
            int divideOn2 = 0;
            int divideOn3 = 0;
            int divideOn4 = 0;

            for(int num = 1; num <= n; num++)
            {
                int number = int.Parse(Console.ReadLine());
                if(number % 2 == 0) divideOn2++;
                if(number % 3 == 0) divideOn3++;
                if(number % 4 == 0) divideOn4++;
            }
            double p1 = divideOn2 / n * 100; Console.WriteLine($"{p1:f2}%");
            double p2 = divideOn3 / n * 100; Console.WriteLine($"{p2:f2}%");
            double p3 = divideOn4 / n * 100; Console.WriteLine($"{p3:f2}%");
        }
    }
}
