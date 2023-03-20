using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace Т09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, bool> removeStartWith = (name, letter) =>
            {
                if (name.Contains(letter))
                    return false;

                else
                    return true;
            };

            Func<string, string, bool> removeEndWith = (name, letter) =>
            {
                if (name.Contains(letter))
                    return false;

                else
                    return true;
            };

            Func<string, int, bool> removeWithLength = (name, length) => name.Length == length ? false : true;

            Func<string[], string, string, string[]> doubleNames = (n, arg, str) =>
            {
                var result = new List<string>(n);
                for (int i = 0; i < n.Length; i++)
                {
                    string name = n[i];
                    if (arg == "StartsWith")
                    {
                        if (name.Contains(str))
                        {
                            result.Insert(i, name);
                        }
                    }

                    else if(arg == "EndsWith")
                    {
                        if (name.Contains(str))
                        {
                            result.Insert(i, name);
                        }
                    }

                    else
                    {
                        if (name.Length == int.Parse(str.ToString()))
                            result.Insert(i, name);
                    }
                }

                return result.ToArray();
            };

            string[] names = Console.ReadLine().Split();
            string[] command;

            while (true)
            {
                command = Console.ReadLine().Split();

                if (command[0] == "Party!")
                {
                    if (names.Length > 0)
                    {
                        Console.WriteLine(string.Join(", ", names) + " are going to the party!");
                    }

                    else
                    {
                        Console.WriteLine("Nobody is going to the party!");
                    }
                    return;
                }

                string cmd = command[0];
                string arg = command[1];
                string str = command[2];
                switch (cmd)
                {
                    case "Remove":
                        if (arg == "StartsWith")
                        {
                            names = names.Where(x => removeStartWith(x, str)).ToArray();
                        }

                        else if (arg == "EndsWith")
                        {
                            names = names.Where(x => removeEndWith(x, str)).ToArray();
                        }

                        else
                        {
                            int length = int.Parse(str.ToString());
                            names = names.Where(x => removeWithLength(x, length)).ToArray();
                        }
                        break;

                    case "Double":
                        names = doubleNames(names, arg, str);
                        break;
                }
            }
        }
    }
}