using System;
using System.Collections.Generic;

namespace T04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shops = new SortedDictionary<string, Dictionary<string, double>>();
            string input;
            while((input = Console.ReadLine()) != "Revision")
            {
                string[] data = input.Split(", ");
                string shop = data[0];
                string product = data[1];
                double price = double.Parse(data[2]);

                if(shops.ContainsKey(shop))
                {
                    shops[shop][product] = price;
                }

                else
                {
                    shops[shop] = new Dictionary<string, double>();
                    shops[shop].Add(product, price);
                }
            }

            foreach(var (shop, products) in shops)
            {
                Console.WriteLine(shop + "->");
                foreach(var product in products)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
