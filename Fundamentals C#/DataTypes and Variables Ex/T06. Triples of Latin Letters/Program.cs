using System;

namespace T06._Triples_of_Latin_Letters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            sbyte n = 3;
            //How to print all triples of the first n small Latin letters
            for (int i = 0;  i < n; i++) {
                char first = (char)('a' + i);
                for (int j = 0; j < n; j++) {
                    char second = (char)('a' + j);
                    for (int k = 0; k < n; k++) {
                        char third = (char)('a' + k);
                        Console.WriteLine($"{first}{second}{third}");
                    }
                }
            }
        }
    }
}
