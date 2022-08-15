using System;

namespace T10.InvalidNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());

            if (num == 0)
            {
                Console.WriteLine("");
            }
            else if (num < 100 || num > 200)
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
