using System;

namespace T14._Password_Generator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int symbol1 = 1; symbol1 <= n; symbol1++)
            {
                for (int symbol2 = 1; symbol2 <= n; symbol2++)
                {
                    for (char symbol3 = 'a'; symbol3 < l + 97; symbol3++) //char 'a' -> 97
                    {
                        for (char symbol4 = 'a'; symbol4 < 97 + l; symbol4++) //char 'a' -> 97
                        {
                            for (int symbol5 = 2; symbol5 <= n; symbol5++)
                            {
                                if (symbol5 > symbol1 && symbol5 > symbol2)
                                {
                                    Console.Write($"{symbol1}{symbol2}{symbol3}{symbol4}{symbol5} ");
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
