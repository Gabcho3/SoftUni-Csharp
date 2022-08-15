using System;

namespace Т03._Passed_or_Failed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var grade = double.Parse(Console.ReadLine());
            if (grade >= 3.00)   
                Console.WriteLine("Passed!");
            else 
                Console.WriteLine("Failed!");
        }
    }
}
