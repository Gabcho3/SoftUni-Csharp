using System;
using System.Text;

namespace Т05._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var digits = new StringBuilder();
            var letters = new StringBuilder();
            var others = new StringBuilder();

            foreach (char ch in input)
            {
                //Using ASCII codes

                if (ch >= 48 && ch <= 57) //char.IsDigit(ch)
                    digits.Append(ch);

                else if (ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122) //char.IsLetter(ch)
                    letters.Append(ch);

                else
                    others.Append(ch);
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
