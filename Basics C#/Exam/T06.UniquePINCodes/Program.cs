using System;

namespace T06.UniquePINCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int interval1 = int.Parse(Console.ReadLine());
            int interval2 = int.Parse(Console.ReadLine());
            int interval3 = int.Parse(Console.ReadLine());

            for (int num1 = 1; num1 <= interval1; num1++)
            {
                if (num1 % 2 != 0)
                {
                    continue;
                }
                for (int num2 = 2; num2 <= interval2; num2++)
                {
                    if (num2 == 4 || num2 == 6 || num2 > 7)
                    {
                        continue;
                    }
                    for (int num3 = 1; num3 <= interval3; num3++)
                    {
                        if (num3 % 2 != 0)
                        {
                            continue;
                        }
                        Console.WriteLine($"{num1} {num2} {num3}");
                    }
                }
            }
        }
    }
}
