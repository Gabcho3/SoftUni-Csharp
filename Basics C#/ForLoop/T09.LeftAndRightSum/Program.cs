using System;

namespace T09.LeftAndRightSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftSide = 0;
            int rightSide = 0;
            int leftSum = 0;
            for(int i = 0; i < n; i++)
            {
                leftSide = int.Parse(Console.ReadLine());
                leftSum += leftSide;
            }
            int rightSum = 0;
            for (int i = 0; i < n; i++)
            {
                rightSide = int.Parse(Console.ReadLine());
                rightSum += rightSide;
            }
            if(leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(leftSum - rightSum)}");
            }
        }
    }
}
