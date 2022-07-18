using System;

namespace T03.DepositCalculator___FirstStepsEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double depsum = double.Parse(Console.ReadLine());
            int mon = int.Parse(Console.ReadLine());
            double pr = double.Parse(Console.ReadLine());
            double pre = pr / 100;
            double total = depsum + mon * ((depsum * pre) / 12);
            Console.WriteLine(total);
        }
    }
}
