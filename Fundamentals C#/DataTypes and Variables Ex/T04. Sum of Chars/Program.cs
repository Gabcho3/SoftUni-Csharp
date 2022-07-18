using System;

namespace T04._Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            sbyte newLines = sbyte.Parse(Console.ReadLine()); //[1…20]
            int sumOfChars = 0;
            for (int i = 1; i <= newLines; i++) {
                char newChar = char.Parse(Console.ReadLine());
                sumOfChars += newChar; //char is ASCII code
            }
            Console.WriteLine($"The sum equals: {sumOfChars}");
        }
    }
}
