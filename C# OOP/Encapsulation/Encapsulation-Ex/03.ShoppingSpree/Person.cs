using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public void AddProducts(Product product)
        {
            if (product.Cost <= Money)
            {
                products.Add(product);
                Money -= product.Cost;
                Console.WriteLine($"{Name} bought {product.Name}");
            }

            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            if(products.Count == 0)
            {
                return $"{Name} - Nothing bought";
            }

            List<string> productsNames = products.Select(x => x.Name).ToList();
            return $"{Name} - {string.Join(", ", productsNames)}";
        }
    }
}
