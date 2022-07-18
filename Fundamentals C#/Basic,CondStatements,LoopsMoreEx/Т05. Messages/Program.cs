using System;

namespace Т05._Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); //how much lines will be INPUT
            for(int i = 1; i <= n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                int digitLength = input.ToString().Length;
                int mainDigit = int.Parse(input.ToString()[0].ToString());

                if(mainDigit == 0)
                {
                    Console.Write(" "); 
                    continue;
                }

                int offset = (mainDigit - 2) * 3;
                if (mainDigit == 8 || mainDigit == 9) offset++;
                int letterIndex = (offset + digitLength - 1) + 'a'; //ASCII code of 'a' (97)
                char output = (char)letterIndex; //(char) --> to make INT in CHAR
                Console.Write(output);
            }
        }
    }

}
