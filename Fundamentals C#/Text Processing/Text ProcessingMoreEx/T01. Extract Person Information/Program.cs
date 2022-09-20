using System;

namespace T01._Extract_Person_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for(int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();

                int startIndexOfName = input.IndexOf('@') + 1;
                int endIndexOfName = input.IndexOf('|');

                int startIndexOfAge = input.IndexOf('#') + 1;
                int endIndexOfAge = input.IndexOf('*');

                int nameLength = endIndexOfName - startIndexOfName;
                int ageLength = endIndexOfAge - startIndexOfAge;

                string name = new string(input.Substring(startIndexOfName, nameLength));
                string age = new string(input.Substring(startIndexOfAge, ageLength));

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
