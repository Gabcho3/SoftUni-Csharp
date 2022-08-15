using System;

namespace T02._Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sumOfDigits = 0;
            for(int i = 0; i < num.ToString().Length; i++) {
                sumOfDigits += int.Parse(num.ToString()[i].ToString());
            }
            Console.WriteLine(sumOfDigits);
        }
    }
}
