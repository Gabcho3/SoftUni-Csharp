using System;
using System.Collections.Generic;

namespace T04._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var userNameAndPlate = new Dictionary<string, string>();

            for(int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                string userName = command[1];

                switch(command[0])
                {
                    case "register":
                        string plateNumber = command[2];
                        Register(userNameAndPlate, userName, plateNumber);
                        break;

                    case "unregister":
                        Unregister(userNameAndPlate, userName);
                        break;
                }
            }

            foreach(var user in userNameAndPlate)
                Console.WriteLine($"{user.Key} => {user.Value}");
        }

        static void Register(Dictionary<string, string> nameAndPlate,  string userName, string plateNumber)
        {
            if(!nameAndPlate.ContainsKey(userName))
            {
                nameAndPlate.Add(userName, plateNumber);
                Console.WriteLine($"{userName} registered {plateNumber} successfully");
            }

            else
                Console.WriteLine($"ERROR: already registered with plate number {plateNumber}");
        }

        static void Unregister(Dictionary<string, string> nameAndPlate, string userName)
        {
            if (!nameAndPlate.ContainsKey(userName))
                Console.WriteLine($"ERROR: user {userName} not found");

            else
            {
                nameAndPlate.Remove(userName);
                Console.WriteLine($"{userName} unregistered successfully");
            }
        }
    }
}
