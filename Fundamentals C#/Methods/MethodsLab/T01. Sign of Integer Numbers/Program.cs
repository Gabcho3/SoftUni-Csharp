using System;

namespace T01._Sign_of_Integer_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            CheckNumber(num);
        }

        static void CheckNumber(int num)
        {
            if (num > 0)
                Console.WriteLine($"The number {num} is positive.");

            else if(num < 0)
                Console.WriteLine($"The number {num} is negative.");

            else
                Console.WriteLine($"The number {num} is zero.");
        }
    }
}
