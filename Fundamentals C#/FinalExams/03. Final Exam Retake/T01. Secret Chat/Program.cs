using System;
using System.Linq;
using System.Transactions;

namespace T01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string[] command = Console.ReadLine().Split(":|:");

            while (command[0] != "Reveal")
            {
                switch(command[0])
                {
                    case "InsertSpace":
                        message = message.Insert(int.Parse(command[1]), " ");
                        break;

                    case "Reverse":
                        int index = message.IndexOf(command[1]);

                        if(index == -1)
                        {
                            Console.WriteLine("error");

                            command = Console.ReadLine().Split(":|:");

                            continue;
                        }

                        message = message.Remove(index, command[1].Length);
                        string substring = string.Empty;

                        for (int i = command[1].Length - 1; i >= 0; i--)
                            substring += command[1][i];

                        message = message.Insert(message.Length, substring);

                        break;

                    case "ChangeAll":
                        message = message.Replace(command[1], command[2]);
                        break;
                }

                Console.WriteLine(message);

                command = Console.ReadLine().Split(":|:");
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
