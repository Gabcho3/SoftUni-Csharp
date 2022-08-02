using System;

namespace T03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char ch1 = char.Parse(Console.ReadLine());
            char ch2 = char.Parse(Console.ReadLine());

            PrintChars(ch1, ch2);
        }

        static void PrintChars(char ch1, char ch2)
        {
            for(int i = ch1 + 1; i < ch2; i++)
            {
                Console.Write((char)i + " ");
            }

            //Swapping chars if the second letter's ASCII value is LESS than that of the first one 
            for (int j = ch2 + 1; j < ch1; j++) 
            {
                Console.Write((char)j + " ");
            }
        }
    }
}
