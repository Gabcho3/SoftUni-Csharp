using System;

namespace T01._Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "Done")
            {
                switch (command[0])
                {
                    case "TakeOdd":
                        string newPassword = string.Empty;

                        for (int i = 0; i < password.Length; i++)
                            if (i % 2 == 1)
                                newPassword += password[i];

                        Console.WriteLine(newPassword);
                        password = newPassword;
                        break;

                    case "Cut":
                        int index = int.Parse(command[1]);
                        int length = int.Parse(command[2]);

                        password = password.Remove(index, length);

                        Console.WriteLine(password);
                        break;

                    case "Substitute":
                        string substring = command[1];
                        string substitute = command[2];

                        if (password.Contains(substring))
                        {
                            password = password.Replace(substring, substitute);
                            Console.WriteLine(password);
                        }

                        else
                            Console.WriteLine("Nothing to replace!");

                        break;
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
