using System;

namespace T08._Secret_Door_s_Lock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            for(int num1 = 2 ; num1 <= first; num1++)
            {
                if (num1 % 2 != 0) continue;
                    for(int num2 = 2; num2 <= second; num2++)
                    {
                        if(num2 == 4 || num2 == 6)
                        {
                            continue;
                        }
                        if(num2 > 7)
                        {
                            break;
                        }
                        for(int num3 = 2; num3 <= third; num3++)
                        {
                            if(num3 % 2 != 0) continue;
                            Console.WriteLine($"{num1} {num2} {num3}");
                        }
                    }
            }
        }
    }
}
