using System;
using System.Linq;

namespace T02._Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "end")
            {
                string action = command[0];

                switch (action)
                {
                    case "swap":

                        int index1 = int.Parse(command[1]);
                        int index2 = int.Parse(command[2]);

                        Swap(input, index1, index2);
                        break;

                    case "multiply":

                        index1 = int.Parse(command[1]);
                        index2 = int.Parse(command[2]);

                        input[index1] *= input[index2];
                        break;

                    case "decrease":
                        for (int i = 0; i < input.Length; i++)
                        {
                            input[i]--;
                        }
                        break;
                }

                command = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine(string.Join(", ", input));
        }

        static void Swap(int[] input, int index1, int index2)
        {
            int onIndex1 = input[index1];
            int onIndex2 = input[index2];

            input[index1] = onIndex2;
            input[index2] = onIndex1;
        }
    }
}
