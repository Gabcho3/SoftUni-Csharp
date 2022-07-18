using System;

namespace T04.SumOfTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int lastNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int combination = 0;
            bool isFound = false;
            for(int a = startNumber; a<= lastNumber; a++)
            {
                for(int b = startNumber; b <= lastNumber; b++)
                {
                    combination++;
                    if (a + b == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{combination} ({a} + {b} = {magicNumber})");
                        isFound = true; 
                            break;
                    }
                }
                if (isFound)
                 break;
            }
            if (!isFound)
            {
                Console.WriteLine($"{combination} combinations - neither equals {magicNumber}");
            }

        }
    }
}
