using System;
using System.Numerics;

namespace T01._World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] command = Console.ReadLine().Split(':');

            while (command[0] != "Travel")
            {
                switch(command[0])
                {
                    case "Add Stop":
                        int index = int.Parse(command[1]);
                        string str = command[2];
                        input = input.Insert(index, str);
                        break;

                    case "Remove Stop":
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);

                        if(startIndex >= 0 && startIndex < input.Length && endIndex >= 0 && endIndex < input.Length)
                            input = input.Remove(startIndex, endIndex - startIndex + 1);
                        break;

                    case "Switch":
                        string oldString = command[1];
                        string newString = command[2];
                        input = input.Replace(oldString, newString);
                        break;
                }

                Console.WriteLine(input);

                command = Console.ReadLine().Split(':');
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }
    }
}