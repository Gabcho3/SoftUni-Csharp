using System;

namespace T05._Print_Part_Of_ASCII_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startCharIndex = int.Parse(Console.ReadLine());
            int lastCharIndex = int.Parse(Console.ReadLine());
            for (int charIndex = startCharIndex; charIndex <= lastCharIndex; charIndex++) {
                Console.Write((char)charIndex + " "); //(char) -> to print char of charIndex, NOT int
            }
        }
    }
}
