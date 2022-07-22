using System;

namespace T03._Stream_Of_Letters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //A - Z --> 65 - 90
            //a - z --> 97 - 122
            string input = Console.ReadLine();

            int countC = 0;
            int countO = 0;
            int countN = 0;

            while (input != "End")
            {
                char letter = char.Parse(input);
                if (letter == 'c')
                {
                    countC++;
                    if (countC > 1)
                        Console.Write(input);
                }
                if (letter == 'o')
                {
                    countO++;
                    if (countO > 1)
                        Console.Write(input);
                }
                if (letter == 'n')
                {
                    countN++;
                    if (countN > 1)
                        Console.Write(input);
                }

                if (countC == 1 && countO == 1 && countN == 1)
                    Console.Write(" ");
                if (letter >= 65 && letter <= 90 || letter >= 97 && letter <= 122)
                    Console.Write(input);
                input = Console.ReadLine();
            }
        }
    }
}
