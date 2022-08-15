using System;
using System.Text;

namespace T07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repeats = int.Parse(Console.ReadLine());

            string result = RepeatString(input, repeats);
            Console.WriteLine(result);
        }

        static string RepeatString(string input, int repeats)
        {
            string result = String.Empty;

            for (int i = 0; i < repeats; i++)
            {
                result += input;
            }
            return result;
        }

        //OTHER SOLUTION

        //static string repeatstring(string input, int repeats)
        //{
        //    stringbuilder result = new stringbuilder();

        //    for (int i = 0; i < repeats; i++)
        //    {
        //        result.append(input);
        //    }
        //    return result.tostring();
        //}
    }
}
