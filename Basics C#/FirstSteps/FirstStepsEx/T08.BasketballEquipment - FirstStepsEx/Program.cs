using System;

namespace T08.BasketballEquipment___FirstStepsEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tax = int.Parse(Console.ReadLine());
            double sh = tax - (tax * 0.40);
            double ot = sh - (sh * 0.20);
            double ba = ot * (1.00 / 4.00);
            double ax = ba * (1.00 / 5.00);
            double total = tax + sh + ot + ba + ax;
            Console.WriteLine(total);
        }
    }
}
