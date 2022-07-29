using System;

namespace T01._Encrypt__Sort__and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            string[] input = new string[lines];

            int[] ascciCode = new int[lines];

            for (int i = 0; i < lines; i++)
            {
                input[i] = Console.ReadLine();
                for (int j = 0; j < input[i].Length; j++)
                {
                    char letter = input[i][j];
                    if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u' ||
                        letter == 'A' || letter == 'E' || letter == 'I' || letter == 'O' || letter == 'U')
                        ascciCode[i] += letter * input[i].Length;

                    else
                        ascciCode[i] += letter / input[i].Length;

                }

                if (i == lines - 1) 
                    Array.Sort(ascciCode); //Sorting in ascending order 
            }

            for(int i = 0; i < ascciCode.Length; i++) //printing nums
            {
                Console.WriteLine(ascciCode[i]); 
            }
        }
    }
}
