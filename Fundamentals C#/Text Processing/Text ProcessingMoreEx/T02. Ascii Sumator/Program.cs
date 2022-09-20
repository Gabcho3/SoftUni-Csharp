using System;

namespace T02._Ascii_Sumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            string str = Console.ReadLine();

            int sum = 0;

            foreach(char ch in str)
                if (ch > first && ch < second)
                    sum += ch;

            Console.WriteLine(sum);
        }
    }
}
