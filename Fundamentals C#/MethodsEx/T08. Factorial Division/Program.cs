using System;

namespace T08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            double factorial1 = CalculateFactorialOfNum1(num1);
            double factorial2 = CalculateFactorialOfNum2(num2);

            double result = factorial1 / factorial2;

            Console.WriteLine($"{result:f2}");
        }

        static double CalculateFactorialOfNum1(int num1)
        {
            double factorial = 1;
            for(int i = 1; i <= num1; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
        private static double CalculateFactorialOfNum2(int num2)
        {
            double factorial = 1;
            for (int i = 1; i <= num2; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
