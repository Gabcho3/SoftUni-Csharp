using System;

namespace T11._Math_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            char @operator = char.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());

            double result = 0;

            switch(@operator)
            {
                case '/':
                   result = Divide(num1, num2);
                    break;
                case '*':
                    result = Multiply(num1, num2);
                    break;
                case '+':
                    result = (Add(num1, num2));
                    break;
                case '-':
                    result = Subtract(num1, num2);
                    break;
            }
            Console.WriteLine(result);
        }

        static double Divide(double num1, double num2)
        {
            return num1 / num2;
        }

        static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }
        static double Add(double num1, double num2)
        {
            return num1 + num2;
        }
        static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }
    }
}
