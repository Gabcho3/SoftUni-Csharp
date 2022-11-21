using System;
using System.Collections.Generic;
using System.Linq;

namespace T10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            var forceSides = new Dictionary<string, List<string>>();

            while(input[0] != "Lumpawaroo")
            {
                string forceUser = string.Empty;
                string forceSide = string.Empty;

                if (input[1] == "|")
                {
                    string input1 = string.Join("", input);
                    string[] split = input1.Split('|');

                    forceUser = split[1];
                    forceSide = split[0];

                    if (!forceSides.ContainsKey(forceSide))
                        forceSides.Add(forceSide, new List<string>());

                    if (!forceSides[forceSide].Contains(forceUser))
                        forceSides[forceSide].Add(forceUser);
                }

                else
                {
                    string input1 = string.Join(" ", input);
                    string[] split = input1.Split(" -> ");

                    forceUser = split[0];
                    forceSide = split[1];

                    if (!forceSides.ContainsKey(forceSide))
                        forceSides.Add(forceSide, new List<string>());

                    string currSide = string.Empty;
                    foreach(var side in forceSides)
                    {
                        if (side.Value.Contains(forceUser))
                        {
                            currSide = side.Key; 
                        }
                    }

                    if (currSide != "")
                    {
                        forceSides[currSide].Remove(forceUser);
                        forceSides[forceSide].Add(forceUser);
                    }

                    else
                        forceSides[forceSide].Add(forceUser);

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

                input = Console.ReadLine().Split();
            }

            foreach(var (side, users) in forceSides.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (users.Count > 0)
                {
                    Console.WriteLine($"Side: {side}, Members: {users.Count}");
                    foreach (var user in users.OrderBy(x => x))
                        Console.WriteLine("! " + user);
                }
            }
        }
    }
}
