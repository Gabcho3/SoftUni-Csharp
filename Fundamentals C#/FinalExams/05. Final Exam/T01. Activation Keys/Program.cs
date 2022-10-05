using System;
using System.Net;

namespace T01._Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string[] instructions = Console.ReadLine().Split(">>>");

            while (instructions[0] != "Generate")
            {
                bool commandContains = false;

                switch(instructions[0])
                {
                    case "Contains":
                        commandContains = true;
                        string substring = instructions[1];

                        if (key.Contains(substring))
                            Console.WriteLine($"{key} contains {substring}");

                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }

                        break;

                    case "Flip":
                        string upperOrLower = instructions[1];
                        int startIndex = int.Parse(instructions[2]);
                        int endIndex = int.Parse(instructions[3]);

                        if (upperOrLower == "Lower")
                        {
                            substring = key.Substring(startIndex, endIndex - startIndex);
                            key = key.Replace(substring, substring.ToLower());
                        }

                        else
                        {
                            substring = key.Substring(startIndex, endIndex - startIndex);
                            key = key.Replace(substring, substring.ToUpper());
                        }
                        break;

                    case "Slice":
                        startIndex = int.Parse(instructions[1]);
                        endIndex = int.Parse(instructions[2]);

                        key = key.Remove(startIndex, endIndex - startIndex);
                        break;
                }

                if (!commandContains)
                    Console.WriteLine(key);

                instructions = Console.ReadLine().Split(">>>");
            }

            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
