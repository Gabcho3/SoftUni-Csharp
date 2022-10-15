using System;

namespace T01._Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double totalPrice = 0;

            while (input != "special" && input != "regular")
            {
                double price = double.Parse(input);

                if (price < 0)
                    Console.WriteLine("Invalid price!");

                else
                    totalPrice += price;

                input = Console.ReadLine();
            }

            if (totalPrice <= 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            double withoutTaxes = totalPrice;
            double taxes = totalPrice * 0.20;
            totalPrice += taxes;

            if (input == "special")
                totalPrice *= 0.90;

            Console.WriteLine($"Congratulations you've just bought a new computer!" +
                $"\nPrice without taxes: {withoutTaxes:f2}$" +
                $"\nTaxes: {taxes:f2}$" +
                $"\n-----------" +
                $"\nTotal price: {totalPrice:f2}$");
        }
    }
}
