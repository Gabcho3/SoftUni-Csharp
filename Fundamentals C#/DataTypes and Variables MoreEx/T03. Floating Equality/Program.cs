using System;

namespace T03._Floating_Equality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = Math.Abs(double.Parse(Console.ReadLine()));
            double num2 = Math.Abs(double.Parse(Console.ReadLine()));

            double eps = 0.000001;

            double diff = Math.Abs(num1 - num2); //because of NEGATIVE number

            if(diff < eps)
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
        }
    }
}
