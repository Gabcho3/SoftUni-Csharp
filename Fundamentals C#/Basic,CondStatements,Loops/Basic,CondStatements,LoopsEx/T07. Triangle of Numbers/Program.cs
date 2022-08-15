using System;

namespace T08._Triangle_of_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for(int i = 1; i <= n; i++) //i -> num for print
            {
                for(int j = 1; j <= i; j++) //<-- how to print every num
                {
                    Console.Write(i + " "); //there is SPACE between nums
                    
                }
                Console.WriteLine(); //new line for each num
            }
        }
    }
}
