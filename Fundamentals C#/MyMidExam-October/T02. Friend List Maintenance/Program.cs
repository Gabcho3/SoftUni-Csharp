using System;

namespace T02._Friend_List_Maintenance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] friends = Console.ReadLine().Split(", ");

            string[] command = Console.ReadLine().Split();

            while (command[0] != "Report")
            {
                switch (command[0])
                {
                    case "Blacklist":
                        Blacklist(friends, command[1]);
                        break;

                    case "Error":
                        Error(friends, int.Parse(command[1]));
                        break;

                    case "Change":
                        Change(friends, int.Parse(command[1]), command[2]);
                        break;
                }

                command = Console.ReadLine().Split();
            }

            int blacklisted = 0;
            int losted = 0;

            for(int i = 0; i < friends.Length; i++)
            {
                if (friends[i] == "Blacklisted")
                    blacklisted++;

                if (friends[i] == "Lost")
                    losted++;
            }

            Console.WriteLine($"Blacklisted names: {blacklisted}");
            Console.WriteLine($"Lost names: {losted}");
            Console.WriteLine(string.Join(" ", friends));
        }

        static void Blacklist(string[] friends, string name)
        {
            for (int i = 0; i < friends.Length; i++)
            {
                if (friends[i] == name)
                {
                    friends[i] = "Blacklisted";
                    Console.WriteLine($"{name} was blacklisted.");
                    return;
                }
            }

            Console.WriteLine($"{name} was not found.");
        }

        static void Error(string[] friends, int index)
        {
            if (index >= 0 && index < friends.Length)
            {
                if (friends[index] != "Blacklisted" && friends[index] != "Lost")
                {
                    Console.WriteLine($"{friends[index]} was lost due to an error.");
                    friends[index] = "Lost";
                    return;
                }
            }
        }

        static void Change(string[] friends, int index, string name)
        {
            if (index >= 0 && index < friends.Length)
            {
                Console.WriteLine($"{friends[index]} changed his username to {name}.");
                friends[index] = name;
            }
        }
    }
}
