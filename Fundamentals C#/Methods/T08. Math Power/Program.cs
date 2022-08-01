using System;

namespace T08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine()); //the base
            int power = int.Parse(Console.ReadLine());  

            double result = MathPower(num, power);
            Console.WriteLine(result);
        }

        static double MathPower(double num, int power)
        {
            double result = 1;

            for(int i = 0; i < power; i++)
            {
                result *= num;
            }

            //OTHER SOLUTION
            //result = Math.Pow(num, power);
            
            return result;
        }
    }
}
