using System;

namespace T02._From_Left_to_the_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            string first = string.Empty;
            string second = string.Empty;
            bool nowIsFirstNum = true;
            int firstSum = 0;
            int secondSum = 0;
            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                int inputLength = input.Length;
                for (int j = 0; j < inputLength; j++)
                {
                    if (input[j] == '-')
                    {
                        continue;
                    }
                    if (input[j] == ' ')
                    {
                        nowIsFirstNum = false;
                        continue;
                    }
                    if (nowIsFirstNum)
                    {
                        first += input[j].ToString();
                    }
                    if (!nowIsFirstNum)
                    {
                        second += input[j].ToString();
                    }
                }
                long firstNum = long.Parse(first);
                long secondNum = long.Parse(second);
                if (firstNum > secondNum)
                {
                    for (int k = 0; k < first.Length; k++)
                        firstSum += int.Parse(first[k].ToString());
                    Console.WriteLine(firstSum);
                    first = null;
                    second = null;
                    firstSum = 0;
                    nowIsFirstNum = true;
                }
                else
                {
                    for (int l = 0; l < second.Length; l++)
                        secondSum += int.Parse(second[l].ToString());
                    Console.WriteLine(secondSum);
                    first = null;
                    second = null;
                    secondSum = 0;
                    nowIsFirstNum = true;
                }
            }
        }
    }
}
