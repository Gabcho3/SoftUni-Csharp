using System;
using System.Linq;

namespace T04._Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            for (int i = 0; i < input.Length / 2; i++)
            {
                string oldElement = input[i];
                input[i] = input[input.Length - 1 - i]; //to reverse input
                input[input.Length - 1 - i] = oldElement;
            }
            Console.WriteLine(string.Join(" ", input));

            //OTHER SOLUTION:
            //Array.Reverse(input);
            //Console.WriteLine(string.Join(" ", input));
        }
    }
}
