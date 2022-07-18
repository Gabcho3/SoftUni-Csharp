using System;

namespace T03.StreamOfLetters
{
    internal class Program

    {
        static void Main(string[] args)
        {
            //string letters = Console.ReadLine();
            //char letter = char.Parse(letters);
            //char c =  'c';
            //char o = 'o';
            //char n = 'n';
            //int C = 0;
            //int O = 0;
            //int N = 0;
            //while (letters != "End")
            //{
            //    if (letter == c) C++;
            //    else if (letter == o) O++;
            //    else if (letter == n) N++;
            //    else Console.Write(letter);
            //    if (C == 2 || O == 2 || N == 2)
            //    {
            //        Console.Write(letter);
            //    }
            //    if (C == 1 && O == 1 && N == 1)
            //    {
            //        Console.Write(" ");
            //    }
            //    letters = Console.ReadLine();
            //    letter = char.Parse(letters);
            //}
            string expression, result = "";
            bool isItCCommand = false, isItOCommand = false, isItNCommand = false;

            while (true)
            {

                expression = Console.ReadLine();

                if (isItCCommand == true && isItNCommand == true && isItOCommand == true)
                {
                    Console.Write(result + " ");
                    result = "";
                    isItCCommand = false;
                    isItNCommand = false;
                    isItOCommand = false;
                }

                if (expression.Equals("End"))
                {
                    break;
                }

                char letter = char.Parse(expression);


                if (((int)letter >= 65 && (int)letter <= 90) || ((int)letter >= 97 && (int)letter <= 122))
                {

                    if (letter == 'c' && isItCCommand == false)
                    {
                        isItCCommand = true;
                        continue;
                    }
                    else if (letter == 'c' && isItCCommand == true)
                    {
                        result = result + "" + letter;
                        continue;
                    }

                    if (letter == 'o' && isItOCommand == false)
                    {
                        isItOCommand = true;
                        continue;
                    }
                    else if (letter == 'o' && isItOCommand == true)
                    {
                        result = result + "" + letter;
                        continue;
                    }

                    if (letter == 'n' && isItNCommand == false)
                    {
                        isItNCommand = true;
                        continue;
                    }
                    else if (letter == 'n' && isItNCommand == true)
                    {
                        result = result + "" + letter;
                        continue;
                    }

                    result = result + "" + letter;

                }
                else
                {
                    continue;
                }

            }
        }
    }
}
