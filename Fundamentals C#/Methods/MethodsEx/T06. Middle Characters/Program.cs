using System;

namespace T06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            PrintMiddleChars(input);
        }

        static void PrintMiddleChars(string input)
        {
            string middleChars = string.Empty;

            int middleCharPosition = 0;

            if (input.Length % 2 != 0)
            {
                middleCharPosition = input.Length / 2; //Math.Ceiling
                middleChars = input[middleCharPosition].ToString();
            }

            //If the length of the string is even there are two middle characters
            else
            {
                middleCharPosition = input.Length / 2 - 1; //-1 --> first index is always ZERO
                middleChars = input[middleCharPosition].ToString() + input[middleCharPosition + 1];
            }

            Console.WriteLine(middleChars);
        }
    }
}
