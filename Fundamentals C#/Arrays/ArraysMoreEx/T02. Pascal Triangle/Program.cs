using System;

namespace T02._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            int[] output = null;

            int[] previousOutput = null;

            for (int i = 1; i <= lines; i++)
            {
                output = new int[i];

                output[0] = 1; //it's always 1
                output[output.Length - 1] = 1; //it's always 1

                for(int k = 1; k < output.Length - 1; k++) //calculating other elements of triangle
                {
                    output[k] = previousOutput[k - 1] + previousOutput[k]; 
                }

                previousOutput = output;

                Console.WriteLine(string.Join(" ", output));
            }
        }
    }
}
