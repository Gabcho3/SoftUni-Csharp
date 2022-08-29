using System;

namespace T01._Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double withoutTaxes = 0;

            while (input != "special" && input != "regular")
            {
                double price = double.Parse(input);

                if (price <= 0)
                    Console.WriteLine("Invalid price!");

                else
                    withoutTaxes += price;


                input = Console.ReadLine();
            }

            double taxes = withoutTaxes * 0.2;
            double total = withoutTaxes + taxes;

            if (input == "special")
                total *= 0.9;

            if (total <= 0)
                Console.WriteLine("Invalid order!");

            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {withoutTaxes:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {total:f2}$");
            }

        }
    }
}
