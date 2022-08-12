using System;

namespace T01._Integer_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int fourthNum = int.Parse(Console.ReadLine());

            //Operations
            int operationAdd = firstNum + secondNum;
            int divide = operationAdd / thirdNum;
            int multyply = divide * fourthNum;

            Console.WriteLine(multyply);
        }
    }
}
