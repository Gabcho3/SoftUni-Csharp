using System;
using System.Collections.Generic;
using System.Text;

namespace T04._Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string encrypt = string.Empty;

            foreach (char ch in input)
            {
                int charCode = ch + 3;
                encrypt += (char)charCode;
            }

            Console.WriteLine(encrypt);
        }
    }
}
