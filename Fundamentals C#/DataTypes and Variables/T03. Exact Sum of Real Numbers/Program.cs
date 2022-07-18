using System;

namespace T03._Exact_Sum_of_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //Number of digits
            decimal exactSum = 0; //decimal -> NOT lose precision
            for (int i = 1; i <= n; i++)
            {
                decimal num = decimal.Parse(Console.ReadLine()); //decimal -> Not lose precision
                exactSum += num;
            }
            Console.WriteLine(exactSum);
        }
    }
}
