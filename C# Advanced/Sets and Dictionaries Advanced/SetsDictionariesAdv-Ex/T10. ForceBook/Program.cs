using System;
using System.Collections.Generic;
using System.Linq;

namespace T10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sides = new Dictionary<string, List<string>>();
            string side, user;

            while (true)
            {
                string[] cmd = Console.ReadLine().Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                if (cmd[0] == "Lumpawaroo")
                {
                    PrintSides(sides);
                    return;
                }

                if (cmd.Length == 1)
                {
                    cmd = cmd[0].Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    user = cmd[0];
                    side = cmd[1];

                    if (!sides.ContainsKey(side))
                    {
                        sides.Add(side, new List<string>());
                    }

                    string oldSide = string.Empty;
                    foreach (var (sideName, usersData) in sides)
                    {
                        foreach (var username in usersData)
                        {
                            if (username == user)
                            {
                                oldSide = sideName;
                                break;
                            }
                        }
                    }
                    sides[side].Add(user);

                    if (oldSide != "")
                    {
                        sides[oldSide].Remove(user);
                    }

                    Console.WriteLine("{0} joins the {1} side!", user, side);
                }

                else
                {
                    side = cmd[0];
                    user = cmd[1];

                    if (!sides.ContainsKey(side))
                    {
                        sides.Add(side, new List<string>());
                    }

                    if (!sides[side].Contains(user))
                        sides[side].Add(user);
                }
            }
        }

        private static void PrintSides(Dictionary<string, List<string>> sides)
        {
            foreach (var (side, members) in sides.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (members.Count > 0)
                {
                    Console.WriteLine("Side: {0}, Members: {1}", side, members.Count);
                }

                foreach (var member in members.OrderBy(x => x))
                {
                    Console.WriteLine("! " + member);
                }
            }
        }
    }
}
