using System;
using System.Linq;
namespace T02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split(" ").ToArray();
            string[] input2 = Console.ReadLine().Split(" ").ToArray();

            for(int i = 0; i < input2.Length; i++)
            {
                for (int j = 0; j < input1.Length; j++)
                {
                    if (input2[i] == input1[j])
                    {
                        Console.Write(input1[j] + " ");
                    }
                }
            }
        }
    }
}
