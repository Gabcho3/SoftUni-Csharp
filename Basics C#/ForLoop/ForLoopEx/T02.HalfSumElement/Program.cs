using System;

namespace T02.HalfSumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int maxNumber = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse((Console.ReadLine()));
                if(maxNumber < num)
                {
                    maxNumber = num;
                }
                sum += num;
            }
            int sumWithoutMax = sum - maxNumber;
            if (sumWithoutMax == maxNumber)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sumWithoutMax}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(maxNumber - sumWithoutMax)}");
            }
        }
    }
}
