using System;

namespace T01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            GetMinNum(num1, num2, num3);
        }

        static void GetMinNum(int num1, int num2, int num3)
        {
            int min = int.MaxValue;

            if (num1 < min)
                min = num1;

            if (num2 < min)
                min = num2;

            if (num3 < min)
                min = num3;

            Console.WriteLine(min);
        }
    }
}
