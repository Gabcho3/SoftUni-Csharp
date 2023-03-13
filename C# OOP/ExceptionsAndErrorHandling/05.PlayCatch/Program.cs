using System;
using System.Linq;
using System.Collections;

namespace _05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int exceptionCount = 0;

            while(exceptionCount < 3)
            {
                string[] command = Console.ReadLine().Split();
                string cmd = command[0];

                try
                {
                    int index = int.Parse(command[1]);

                    switch (cmd)
                    {
                        case "Replace":
                            int element = int.Parse(command[2]);
                            ints[index] = element;
                            break;

                        case "Print":
                            int endIndex = int.Parse(command[2]);
                            int[] subArray = new int[endIndex - index + 1];
                            int subArrayIndex = 0;
                            for (int i = index; i <= endIndex; i++)
                                subArray[subArrayIndex++] = ints[i];

                            Console.WriteLine(string.Join(", ", subArray));
                            break;

                        case "Show":
                            Console.WriteLine(ints[index]);
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionCount++;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionCount++;
                }
            }
            Console.WriteLine(string.Join(", ", ints));
        }
    }
}
