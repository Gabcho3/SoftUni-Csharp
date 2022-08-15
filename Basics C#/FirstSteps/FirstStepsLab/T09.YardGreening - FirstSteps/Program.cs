using System;

namespace T09.YardGreening___FirstSteps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double m2 = double.Parse(Console.ReadLine());
            double price = m2 * 7.61;
            double discount = price * 0.18;
            double total = price - discount;
            Console.WriteLine($"The final price is: {total} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
