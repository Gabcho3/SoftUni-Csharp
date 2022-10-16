using System;
using System.Linq;

namespace T02._Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                int index1 = 0;
                int index2 = 0;
                int num1 = 0;
                int num2 = 0;

                if (command.Length > 1)
                {
                    index1 = int.Parse(command[1]);
                    index2 = int.Parse(command[2]);
                    num1 = integers[index1];
                    num2 = integers[index2];
                }

                switch (command[0])
                {
                    case "swap":
                        integers[index1] = num2;
                        integers[index2] = num1;
                        break;

                    case "multiply":
                        integers[index1] *= num2;
                        break;

                    case "decrease":
                        for (int i = 0; i < integers.Length; i++)
                            integers[i]--;
                        break;
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(", ", integers));
        }
    }
}
