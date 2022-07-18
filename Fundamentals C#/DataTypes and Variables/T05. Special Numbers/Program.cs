using System;

namespace T05._Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //number of digits

            for (int num = 1; num <= n; num++)
            {
                int sumOfDigits = 0;
                int digits = num;
                while (digits > 0)
                {
                    sumOfDigits += digits % 10;
                    digits /= 10;
                }
                Console.WriteLine(sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11 ? $"{num} -> True" : $"{num} -> False");
            }

            //OTHER SOLUTION
            //for (int num = 1; num <= n; num++)
            //{
            //    int sum = 0;
            //    int numLength = num.ToString().Length;
            //    for (int i = 0; i < numLength; i++)
            //    {
            //        sum += int.Parse(num.ToString()[i].ToString());
            //    }
            //    Console.WriteLine(sum == 5 || sum == 7 || sum == 11 ? $"{num} -> True" : $"{num} -> False");
            //}
        }
    }
}
