using System;

namespace T06._Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string result = string.Empty;

            for(int i = 0; i < input.Length; i++)
            {
                if (i == input.Length - 1)
                {
                    result += input[i];
                    break;
                }

                else if (input[i] != input[i + 1])
                    result += input[i];
            }

            Console.WriteLine(result);
        }
    }
}
