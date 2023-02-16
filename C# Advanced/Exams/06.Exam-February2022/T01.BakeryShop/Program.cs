using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)         
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));

            Dictionary<string, double> bakaryProducts = new Dictionary<string, double>() //product, %water
            {
                ["Croissant"] = 50,
                ["Muffin"] = 40,
                ["Baguette"] = 30,
                ["Bagel"] = 20
            };

            Dictionary<string, int> usedProducts = new Dictionary<string, int>();

            while (water.Count > 0 && flour.Count > 0)
            {
                double sum = water.Peek() + flour.Peek();
                double waterPercentage = (water.Peek() * 100) / sum;

                if (bakaryProducts.Any(x => x.Value == waterPercentage))
                {
                    var product = bakaryProducts.Where(x => x.Value == waterPercentage).First();

                    if (!usedProducts.ContainsKey(product.Key))
                    {
                        usedProducts.Add(product.Key, 0);
                    }
                    usedProducts[product.Key]++;
                    flour.Pop();
                }

                else
                {
                    if (!usedProducts.ContainsKey("Croissant"))
                    {
                        usedProducts.Add("Croissant", 0);
                    }
                    usedProducts["Croissant"]++;
                    flour.Push(flour.Pop() - water.Peek());
                }

                water.Dequeue();
            }
            PrintProducts(usedProducts);
            Console.WriteLine(water.Count > 0 ? $"Water left: {string.Join(", ", water)}" : "Water left: None");
            Console.WriteLine(flour.Count > 0 ? $"Flour left: {string.Join(", ", flour)}" : "Flour left: None");

        }

        private static void PrintProducts(Dictionary<string, int> usedProducts)
        {
            foreach(var (product, amount) in usedProducts.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{product}: {amount}");
            }
        }
    }
}
