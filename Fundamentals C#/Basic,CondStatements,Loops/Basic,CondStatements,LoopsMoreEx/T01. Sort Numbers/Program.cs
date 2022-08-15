using System;

namespace T01._Sort_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int max = int.MinValue; //biggest num
            int min = int.MaxValue; //smallest num
            int between = 0; //second num in output
            for(int num = 1; num <= 3; num++)
            {
                //For biggest num in OUTPUT
                if (thirdNum > max) max = thirdNum;
                if (secondNum > max) max = secondNum;
                if (firstNum > max) max = firstNum;

                //For smallest num in OUTPUT
                if (thirdNum < min) min = thirdNum;
                if (secondNum < min) min = secondNum;
                if (firstNum < min) min = firstNum;

                //For second num in OUTPUT
                if (firstNum == max && secondNum == min) between = thirdNum;
                if (firstNum == max && thirdNum == min) between = secondNum;

                if (secondNum == max && firstNum == min) between = thirdNum;
                if (secondNum == max && thirdNum == min) between = firstNum;

                if (thirdNum == max && firstNum == min) between = secondNum;
                if (thirdNum == max && secondNum == min) between = firstNum;
            }
            Console.WriteLine(max);
            Console.WriteLine(between);
            Console.WriteLine(min);
        }
    }
}
