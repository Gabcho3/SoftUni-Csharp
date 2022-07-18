using System;

namespace T10._Multiplication_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int product = 0;
            for(int times = 1; times <= 10; times++)
            {
                product = num * times;
                Console.WriteLine($"{num} X {times} = {product}");
            }
        }
    }
}
