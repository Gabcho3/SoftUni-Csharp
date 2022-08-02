using System;

namespace T02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            GetVowelsCount(input);
        }

        static void GetVowelsCount(string input)
        {
            int vowelsCount = 0;

            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' || input[i] == 'e' || input[i] == 'i' || input[i] == 'o' || input[i] == 'u' ||
                    input[i] == 'A' || input[i] == 'E' || input[i] == 'I' || input[i] == 'O' || input[i] == 'U')
                    vowelsCount++;
            }

            Console.WriteLine(vowelsCount);
        }
    }
}
