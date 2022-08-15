using System;

namespace T11._Odd_Even_Position
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double oddSum = 0;
            double oddMin = int.MaxValue;
            double oddMax = int.MinValue;
            double evenSum = 0;
            double evenMin = int.MaxValue;
            double evenMax = int.MinValue;
            bool noOddMin = false;
            bool noEvenMin = false;
            for(int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if (n == 1)
                {
                    noEvenMin = true;
                }

                if (i % 2 != 0)
                {
                    oddSum += num;
                    if (num < oddMin) oddMin = num;
                    if (num > oddMax) oddMax = num;
                }
                else
                {
                    evenSum += num;
                    if (num < evenMin) evenMin = num;
                    if (num > evenMax) evenMax = num;
                }
            }
            if(n == 0)
            {
                noEvenMin = true;
                noOddMin = true;
            }
            Console.WriteLine($"OddSum={oddSum:f2},");
            if(noOddMin)
            {
                Console.WriteLine($"OddMin=No,");
                Console.WriteLine($"OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
                Console.WriteLine($"OddMax={oddMax:f2},");
            }
            Console.WriteLine($"EvenSum={evenSum:f2},");
            if (noEvenMin)
            {
                Console.WriteLine($"EvenMin=No,");
                Console.WriteLine($"EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMin={evenMin:f2},");
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }

        }
    }
}
