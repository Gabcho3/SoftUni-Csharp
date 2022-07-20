using System;

namespace T06._Balanced_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int openedBrackets = 0;
            int closedBrackets = 0;
            for(int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                if(input == "(")
                {
                    openedBrackets++;
                    if(openedBrackets - closedBrackets == 2)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                }
                if(input == ")")
                {
                    closedBrackets++;
                    if (openedBrackets - closedBrackets != 0)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                }
            }
            if (openedBrackets != closedBrackets)
            {
                Console.WriteLine("UNBALANCED");
                return;
            }
            else
            {
                Console.WriteLine("BALANCED");
                return;
            }
        }
    }
}
