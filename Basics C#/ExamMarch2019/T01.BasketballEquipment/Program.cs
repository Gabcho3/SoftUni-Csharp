using System;

namespace T01.BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tax = int.Parse(Console.ReadLine());

            double priceShoes = tax - (tax * 0.40);
            double equipment = priceShoes - (priceShoes * 0.20);
            double ball = equipment * 1.0 / 4.0;
            double accessories = ball * 1.0 / 5.0;

            double total = tax + priceShoes + equipment + ball + accessories;
            Console.WriteLine($"{total:f2}");
        }
    }
}
