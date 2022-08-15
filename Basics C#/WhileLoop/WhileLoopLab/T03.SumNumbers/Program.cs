using System;

namespace T03.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            while (sum < number)
            {
                int inputNumbers = int.Parse(Console.ReadLine());
                sum += inputNumbers;
            }
            Console.WriteLine(sum); 
        }
    }
}
