using System;
using System.Collections.Generic;

namespace T03._Take_Skip_Rope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> numbers = new List<int>();
            List<string> nonNumbers = new List<string>();

            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 48 && input[i] <= 57)
                    numbers.Add(int.Parse(input[i].ToString())); //taking digits

                else
                    nonNumbers.Add(input[i].ToString()); //taking string
            }

            List<int> take = new List<int>();
            List<int> skip = new List<int>();

            FindTakeAndSkip(nonNumbers, numbers, take, skip);
        }

        static void FindTakeAndSkip(List<string> nonNumbers, List<int> numbers, List<int> take, List<int> skip)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                    take.Add(numbers[i]);

                else
                    skip.Add(numbers[i]);
            }

            PrintResult(nonNumbers, take, skip);
        }

        static void PrintResult(List<string> nonNumbers, List<int> take, List<int> skip)
        {
            string result = "";

            for (int i = 0; i < nonNumbers.Count; i++)
            {
                for (int j = 0; j < take.Count; j++)
                {
                    int takeCount = 0; //every time reseting counter

                    if (take[j] == 0)
                        result += ""; //0 chars to bring

                    while (takeCount != take[j] && i < nonNumbers.Count)
                    {
                        result += nonNumbers[i];

                        takeCount++;
                        i++;
                    }

                    i += skip[j]; //skipping chars
                }
                break; //no more take/skip
            }

            Console.WriteLine(result);
        }
    }
}
