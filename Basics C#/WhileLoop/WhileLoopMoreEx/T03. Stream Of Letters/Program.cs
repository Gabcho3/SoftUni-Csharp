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

            bool c = false;
            bool o = false;
            bool n = false;

            while (input != "End")
            {
                char letter = char.Parse(input);
                string word = null;

                if (letter == 'c')
                {
                    countC++;
                    if (countC > 1)
                        word += input;
                }
                else if (letter == 'o')
                {
                    countO++;
                    if (countO > 1)
                        word += input;
                }
                else if (letter == 'n')
                {
                    countN++;
                    if (countN > 1)
                        word += input;
                }
                else if (letter >= 65 && letter <= 90 || letter >= 97 && letter <= 122)
                    word += input;

                if (countC == 1 && countO == 1 && countN == 1)
                {
                    Console.Write(word);
                    word = null;
                    Console.Write(" ");

                    countC = 0;
                    countO = 0;
                    countN = 0;

                    c = true;
                    o = true;
                    n = true;
                }
                input = Console.ReadLine();
            }
        }
    }
}
