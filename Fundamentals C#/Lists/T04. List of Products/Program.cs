using System;
using System.Collections.Generic;

namespace T04._List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();

            AddProduct(lines, products);
            PrintListOfProducts(products, lines);
        }
        
        static List<string> AddProduct(int lines, List<string> products)
        {
            for (int line = 0; line < lines; line++)
            {
                string product = Console.ReadLine();

                products.Add(product);
            }
            return products;
        }

        static void PrintListOfProducts(List<string> products, int lines)
        {
            products.Sort();

            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine($"{i + 1}.{products[i]}");
            }
        }
    }
}
