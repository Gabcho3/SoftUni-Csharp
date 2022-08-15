using System;

namespace T03.EnergyBooster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            int ordered = int.Parse(Console.ReadLine());

            double priceForSet = 0;
            double price = 0;
            double totalPrice = 0;

            switch(fruit)
            {
                case "Watermelon":
                if(size == "small")
                {
                     priceForSet = 2 * 56;
                     price = ordered * priceForSet;
                     totalPrice = price;
                     if(price >= 400 && price <= 1000) totalPrice = price - (price * 0.15);
                     if (price > 1000) totalPrice = price - (price * 0.50);
                }
                if(size == "big")
                {
                        priceForSet = 5 * 28.70;
                        price = ordered * priceForSet;
                        totalPrice = price;
                        if (price >= 400 && price <= 1000) totalPrice = price - (price * 0.15);
                        if (price > 1000) totalPrice = price - (price * 0.50);
                    }
                    break;  
                case "Mango":
                    if (size == "small")
                    {
                        priceForSet = 2 * 36.66;
                        price = ordered * priceForSet;
                        totalPrice = price;
                        if (price >= 400 && price <= 1000) totalPrice = price - (price * 0.15);
                        if (price > 1000) totalPrice = price - (price * 0.50);
                    }
                    if (size == "big")
                    {
                        priceForSet = 5 * 19.60;
                        price = ordered * priceForSet;
                        totalPrice = price;
                        if (price >= 400 && price <= 1000) totalPrice = price - (price * 0.15);
                        if (price > 1000) totalPrice = price - (price * 0.50);
                    }
                    break;
                case "Pineapple":
                    if (size == "small")
                    {
                        priceForSet = 2 * 42.10;
                        price = ordered * priceForSet;
                        totalPrice = price;
                        if (price >= 400 && price <= 1000) totalPrice = price - (price * 0.15);
                        if (price > 1000) totalPrice = price - (price * 0.50);
                    }
                    if (size == "big")
                    {
                        priceForSet = 5 * 24.80;
                        price = ordered * priceForSet;
                        totalPrice = price;
                        if (price >= 400 && price <= 1000) totalPrice = price - (price * 0.15);
                        if (price > 1000) totalPrice = price - (price * 0.50);
                    }
                    break;
                case "Raspberry":
                    if (size == "small")
                    {
                        priceForSet = 2 * 20;
                        price = ordered * priceForSet;
                        totalPrice = price;
                        if (price >= 400 && price <= 1000) totalPrice = price - (price * 0.15);
                        if (price > 1000) totalPrice = price - (price * 0.50);
                    }
                    if (size == "big")
                    {
                        priceForSet = 5 * 15.20;
                        price = ordered * priceForSet;
                        totalPrice = price;
                        if (price >= 400 && price <= 1000) totalPrice = price - (price * 0.15);
                        if (price > 1000) totalPrice = price - (price * 0.50);
                    }
                    break;
            }
            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}
