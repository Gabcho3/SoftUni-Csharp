using System;

namespace T03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int index = input.LastIndexOf('\\');

            input = input.Substring(index + 1);

            index = input.IndexOf('.');

            string name = new string(input.Substring(0, index)); //start index, length -> from start of input to '.'
            string extension = new string(input.Substring(index + 1)); //start index -> from '.' to end of input

            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
