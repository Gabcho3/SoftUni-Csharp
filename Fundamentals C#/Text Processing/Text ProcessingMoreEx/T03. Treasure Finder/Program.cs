using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while(true)
            {
                string input = Console.ReadLine();

                string output = string.Empty;

                if (input == "find")
                    break;

                int index = 0;

                while (input.Length != output.Length)
                {
                    for (int i = 0; i < key.Length; i++)
                    {
                        output += (char)(input[index] - key[i]);

                        index++;

                        if (index > input.Length - 1)
                            break;
                    }

                    if (index > input.Length - 1)
                        break;
                }

                int typeIndex = output.IndexOf('&') + 1;
                int typeLength = output.LastIndexOf('&') - typeIndex;

                int corIndex = output.IndexOf('<') + 1;
                int corLength = output.IndexOf('>') - corIndex;

                string type = output.Substring(typeIndex, typeLength);
                string coordinates = output.Substring(corIndex, corLength);

                Console.WriteLine($"Found {type} at {coordinates}");
            }
        }
    }
}
