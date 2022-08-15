using System;

namespace T02.EqualSumsEvenOddPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            for(int i = num1; i <= num2; i++)
            {
                string curentNum = i.ToString();
                int oddSum = 0;
                int evenSum = 0;
                for(int j = 0; j < curentNum.Length; j++)
                {
                    int currentDigit = int.Parse(curentNum[j].ToString());
                    if(j % 2 == 0)
                    {
                        evenSum += currentDigit;
                    }
                    else
                    {
                        oddSum += currentDigit;
                    }
                }
                if(oddSum == evenSum)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
