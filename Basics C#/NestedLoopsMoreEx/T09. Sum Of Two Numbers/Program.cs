using System;

namespace T09._Sum_Of_Two_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int num1, num2 = 0;
            int combinations = 0;
            bool found = false;
            for(num1 = start; num1 <= end; num1++)
            {
                for(num2 = start; num2 <= end; num2++)
                {
                    combinations++;
                    if(num1 + num2 == magicNum)
                    {
                        found = true;
                        break;
                    }
                }
                if(found)
                {
                    break;
                }
            }
            if(found)
            {
                Console.WriteLine($"Combination N:{combinations} ({num1} + {num2} = {magicNum})");
            }
            else
            {
                Console.WriteLine($"{combinations} combinations - neither equals {magicNum}");
            }
        }
    }
}
