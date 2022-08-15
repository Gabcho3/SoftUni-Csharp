using System;

namespace T09._SumOfOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int odd = 1;
            var sum = 0;
            for(int i = 1; i <= n; i++)
            {
                sum += odd;
                Console.WriteLine(odd);
                odd += 2;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
