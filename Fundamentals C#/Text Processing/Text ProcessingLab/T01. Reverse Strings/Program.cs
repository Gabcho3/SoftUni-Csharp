using System;
using System.Linq;

namespace T01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while(input != "end")
            {
                input = Console.ReadLine();

                string reversed = string.Empty;

                for(int i = input.Length - 1; i >= 0; i--)
                {
                    reversed += input[i];
                }

                Console.WriteLine($"{input} = {reversed}");
            }
        }
    }
}
