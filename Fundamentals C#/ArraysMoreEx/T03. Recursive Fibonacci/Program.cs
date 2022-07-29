using System;

namespace T03._Recursive_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wantedNum = int.Parse(Console.ReadLine());
            

            int[] output = new int[2]; //first amd second num is always 1

            while(true) //to save output[0] and output[1] && to make new output every time
            {
                output[0] = 1; //always 1
                output[1] = 1; //always 1

                for(int i = 2; i < output.Length; i++) //calculating other elements
                {
                    output[i] = output[i - 1] + output[i  - 2]; //formula
                    if (i + 1 == wantedNum) //i + 1 --> i'th Fibonacci number counting from 1.
                    {
                        Console.WriteLine(output[i]);
                        return;
                    }
                    
                }
                output = new int[output.Length + 1];
            }
        }
    }
}
