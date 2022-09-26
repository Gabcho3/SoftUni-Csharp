using System;

namespace T01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] command = Console.ReadLine().Split('|');

            while (command[0] != "Decode")
            {
                switch (command[0])
                {
                    case "Move":
                        input = Move(input, command);
                        break;

                    case "Insert":
                        input = Insert(input, command);
                        break;

                    case "ChangeAll":
                        input = ChangeAll(input, command);
                        break;
                }

                command = Console.ReadLine().Split('|');
            }

            Console.WriteLine($"The decrypted message is: {input}");
        }

        static string Move(string input, string[] command)
        {
            int numOfLetters = int.Parse(command[1]);

            string replace = string.Empty;

            for (int i = 0; i < numOfLetters; i++)
                replace += input[i];

            input = input.Remove(0, numOfLetters);
            input = input.Insert(input.Length, replace);

            return input;
        }

        static string Insert(string input, string[] command)
        {
            int index = int.Parse(command[1]);

            string value = command[2];

            input = input.Insert(index, value);

            return input;
        }

        static string ChangeAll(string input, string[] command)
        {
            char subtsring = char.Parse(command[1]);
            char replacement = char.Parse(command[2]);

            input = input.Replace(subtsring, replacement);

            return input;
        }
    }
}
