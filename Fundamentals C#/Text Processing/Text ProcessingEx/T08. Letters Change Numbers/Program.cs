using System;

namespace T08._Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double sum = 0;

            for(int i = 0; i < input.Length; i++)
            {
                char firstLetter = input[i][0];
                char secondLetter = input[i][input[i].Length - 1];

                double num = int.Parse(new string(input[i].Substring(1, input[i].Length - 2)));

                if (char.IsLower(firstLetter))
                    sum += (firstLetter - 96) * num; //ascii code of "a" = 97 (a's position in the alphabet is 1st)

                else
                    sum += num / (firstLetter - 64); //ascii code of "A" = 65 (a's position in the alphabet is 1st)

                if (char.IsLower(secondLetter))
                    sum += secondLetter - 96;

                else
                    sum -= secondLetter - 64;
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}
