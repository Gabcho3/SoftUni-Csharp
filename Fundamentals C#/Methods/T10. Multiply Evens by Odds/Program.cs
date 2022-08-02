using System;

namespace T10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = Math.Abs(int.Parse(Console.ReadLine())); //Math.Abs() --> for negative nums

            int evenSum = GetSumOfEvenDigits(num);
            int oddSum = GetSumOfOddDigits(num);
            int result = GetMultipleOfEvenAndOdds(evenSum, oddSum);

            Console.WriteLine(result);
        }

        static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }

        static int GetSumOfEvenDigits(int num)
        {
            int sum = 0;
            int digits = num;

            while(digits > 0)
            {
                int currDigit = digits % 10;

                if (currDigit % 2 == 0)
                    sum += currDigit;

                digits = digits / 10;
            }

            return sum;
        }

        static int GetSumOfOddDigits(int num)
        {
            int sum = 0;
            int digits = num;

            while (digits > 0)
            {
                int currDigit = digits % 10;

                if (currDigit % 2 != 0)
                    sum += currDigit;

                digits = digits / 10;
            }

            return sum;
        }
    }
}
