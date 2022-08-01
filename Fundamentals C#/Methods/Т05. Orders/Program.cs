using System;

namespace Т05._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //coffeePrice = 1.50;
            //waterPrice = 1.00;
            //cokePrice = 1.40;
            //snacksPrice = 2.00;

            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            PrintPrice(product, quantity);
        }

        static void PrintPrice(string product, int quantity)
        {
            double totalPrice = 0;

            switch(product)
            {   
                case "coffee":
                    totalPrice = quantity * 1.50;
                    break;
                case "water":
                    totalPrice = quantity * 1.00;
                    break;
                case "coke":
                    totalPrice = quantity * 1.40;
                    break;
                case "snacks":
                    totalPrice = quantity * 2.00;
                    break;
            }

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
