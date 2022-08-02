using System;

namespace T05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int sum = AddTwoNums(num1, num2);
            int result = Subtract(num3, sum);

            Console.WriteLine(result);
        }
        static int AddTwoNums(int num1, int num2)
        {
            return num1 + num2;
        }

        static int Subtract(int num3, int sum)
        {
            return sum - num3;
        }

    }
}
