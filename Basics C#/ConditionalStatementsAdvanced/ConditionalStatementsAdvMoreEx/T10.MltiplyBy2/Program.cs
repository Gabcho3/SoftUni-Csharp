using System;

namespace T10.MltiplyBy2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            bool negative = false;
            while(num >= 0)
            {
                double result = num * 2;
                Console.WriteLine($"Result: {result:f2}");
                num = double.Parse(Console.ReadLine());
                negative = true;
            }
            if(negative)
            {
                Console.WriteLine($"Negative number!");
            }
        }
    }
}
