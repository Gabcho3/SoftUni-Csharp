using System;

namespace T03.LuckyNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;
            bool isSpecial = false;
            for(int num = 1000; num <= 9999; num++)
            {
                isSpecial = false;
                string everyNum = num.ToString();
                for(int i = 0; i < everyNum.Length; i++)
                {
                    int number = int.Parse(everyNum[i].ToString());
                    if(number == 0)
                    {
                        sum1 = 1; sum2 = 0;
                        break;
                    }
                    if(i == 0 || i == 1)
                    {
                        sum1 += number;
                    }
                    else
                    {
                        sum2 += number;
                    }
                }
                if (N % sum1 == 0 && sum1 == sum2)
                {
                    isSpecial = true;
                }
                sum1 = 0;
                sum2 = 0;
                if(isSpecial)
                {
                    Console.Write($"{num} ");
                }
            }
            Console.WriteLine();
        }
    }
}
