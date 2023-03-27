using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;
        //private List<string> sizes = new List<string>() { "Small", "Middle", "Large" };

        public Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Size { get { return size; } private set { size = value; } }

        public double Price
        {
            get { return price; }
            private set
            {
                switch (size)
                {
                    case "Large": price = value; break;
                    case "Middle": price = value * (2.0 / 3.0); break;
                    case "Small": price = value * (1.0 / 3.0); break;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} ({size}) - {Price:f2} lv";
        }
    }
}
