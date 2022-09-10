using System;
using System.Collections.Generic;
using System.Linq;

namespace Т03._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            List<Product> products = new List<Product>();
            var productsPrice = new Dictionary<string, decimal>();

            while (input[0] != "buy")
            {
                string name = input[0];
                decimal price = decimal.Parse(input[1]);
                int quantity = int.Parse(input[2]);

                foreach(var pr in products)
                    if(pr.Name == name)
                    {
                        pr.Quantity += quantity;
                        pr.Price = price;
                    }

                if(!products.Any(p => p.Name == name))
                {
                    var product = new Product()
                    {
                        Name = name,
                        Price = price,
                        Quantity = quantity
                    };

                    products.Add(product);
                }

                input = Console.ReadLine().Split();
            }

            foreach(var pr in products)
                productsPrice.Add(pr.Name, pr.Quantity * pr.Price);


            foreach(var product in productsPrice)
                Console.WriteLine($"{product.Key} -> {product.Value:f2}");
        }

        class Product
        {
            public string Name { get; set; }

            public decimal Price { get; set; }

            public int Quantity { get; set; }
        }
    }
}