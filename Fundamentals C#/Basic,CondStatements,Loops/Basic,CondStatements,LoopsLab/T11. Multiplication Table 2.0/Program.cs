using System;

namespace T11._Multiplication_Table_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());
            int product = 0;
            for (int times = multiplier; times <= 10; times++)
            {
                product = num * times;
                Console.WriteLine($"{num} X {times} = {product}");
            }
            if(multiplier > 10)
            {
                Console.WriteLine($"{num} X {multiplier} = {num * multiplier}");
            }
        }
    }
}
