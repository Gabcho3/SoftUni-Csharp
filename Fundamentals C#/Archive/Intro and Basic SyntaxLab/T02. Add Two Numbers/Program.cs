using System;

namespace T02._Add_Two_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int sum = firstNum + secondNum;
            Console.WriteLine("{0} + {1} = {2}", firstNum, secondNum, sum);
        }
    }
}
