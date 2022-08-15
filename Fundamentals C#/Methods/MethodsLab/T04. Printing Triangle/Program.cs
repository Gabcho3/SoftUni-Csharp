using System;

namespace T04._Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            PrintWholeTrngle(input);
        }

        static void PrinLine(int start, int end)
        {
            for(int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        static void PrintWholeTrngle(int input)
        {
            for(int i = 1; i <= input; i++)
            {
                PrinLine(1, i);
            }
            for (int i = input - 1; i >= 1; i--)
            {
                PrinLine(1, i);
            }
        }
    }
}
