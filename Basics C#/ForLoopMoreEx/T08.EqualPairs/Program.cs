using System;

namespace T08.EqualPairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sumCheck = 0; //number for checking maxdiff
            int diff = int.MinValue;
            int maxDiff = 0;
            bool check = false;

            for (int i = 1; i <= n; i++)
            {
                int number1 = int.Parse(Console.ReadLine());
                int number2 = int.Parse(Console.ReadLine());
                
                if (i == 1)
                {
                    sum1 = number1 + number2;
                    sumCheck = sum1;
                }
                else if(i != 0)
                {
                    maxDiff = Math.Abs(sumCheck - (number1 + number2));
                    if(maxDiff > diff) diff = maxDiff;
                    sumCheck = number1 + number2;
                    if(sum1 == sumCheck) check = true;
                }
                
            }
            if(check|| n == 1)
            {
                Console.WriteLine($"Yes, value={sum1}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
        }
    }
}
