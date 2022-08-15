using System;

namespace T05._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();
            string correctPass = "";
            int fails = 0;
            for (int i = username.Length - 1; i >= 0; i--) //to reverse string
            {
                correctPass += username[i];
            }
            while (true)
            {
                if (password == correctPass)
                {
                    Console.WriteLine($"User {username} logged in.");
                    return;
                }
                else
                {
                    fails++;
                    if (fails == 4)
                    { 
                        Console.WriteLine($"User {username} blocked!");
                        return;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
                password = Console.ReadLine();
            }
        }
    }
}
