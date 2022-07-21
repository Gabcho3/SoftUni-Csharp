using System;

namespace T04._Refactoring_Prime_Checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine()); //changed name 
            for (int num = 2; num <= range; num++) //changed name
            {
                bool isPrime = true; //changed name
                for (int divider = 2; divider < num; divider++) //changed name
                {
                    if (num % divider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine(isPrime ? $"{num} -> true": $"{num} -> false"); //chanhged structure
            }

        }
    }
}
