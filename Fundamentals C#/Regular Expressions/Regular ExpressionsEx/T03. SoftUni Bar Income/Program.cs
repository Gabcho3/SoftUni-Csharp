using System;
using System.Text.RegularExpressions;

namespace T03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>[\w]+)>[^|$%.]*\|(?<count>[\d]+)\|[^|$%.]*?(?<price>\d+[.]?\d+)\$";

            string order = Console.ReadLine();

            double totalSum = 0;

            while (order != "end of shift")
            {
                Regex regex = new Regex(patern);
                Match validOrders = regex.Match(order);

                if (!validOrders.Success)
                {
                    order = Console.ReadLine();
                    continue;
                }

                var customer = validOrders.Groups["customer"].Value;
                var product = validOrders.Groups["product"].Value;
                var price = double.Parse(validOrders.Groups["count"].Value) * double.Parse(validOrders.Groups["price"].Value);

                totalSum += price;

                Console.WriteLine($"{customer}: {product} - {price:f2}");

                order = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}
