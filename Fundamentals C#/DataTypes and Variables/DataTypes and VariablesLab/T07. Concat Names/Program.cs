using System;

namespace T07._Concat_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstname = Console.ReadLine();
            string secondName = Console.ReadLine();
            string delimeter = Console.ReadLine();
            Console.WriteLine($"{firstname}{delimeter}{secondName}");
        }
    }
}
