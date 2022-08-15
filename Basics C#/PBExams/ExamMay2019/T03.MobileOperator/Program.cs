using System;

namespace T03.MobileOperator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string term = Console.ReadLine();
            string type  = Console.ReadLine();
            string mobile = Console.ReadLine();
            int months = int.Parse(Console.ReadLine());
            double price = 0;

            switch(type)
            {
                case "Small":
                    price = 9.98;
                    if (term == "two") price = 8.58;
                    if (mobile == "yes")
                    {
                        price += 5.50;
                    }
                        if (term == "two") price -= price * 0.0375;
                    break;
                case "Middle":
                    price = 18.99;
                    if (term == "two") price = 17.09;
                    if (mobile == "yes")
                    {
                        price += 4.35;
                    }
                        if (term == "two") price -= price * 0.0375;
                    break;
                case "Large":
                    price = 25.98;
                    if (term == "two") price = 23.59;
                    if (mobile == "yes")
                    {
                        price += 4.35;
                    }
                        if (term == "two") price -= price * 0.0375;
                    break;
                case "ExtraLarge":
                    price = 35.99;
                    if (term == "two") price = 31.79;
                    if (mobile == "yes")
                    {
                        price += 3.85;
                    }
                        if (term == "two") price -= price * 0.0375;
                    break;
            }
            price *= months;
            Console.WriteLine($"{price:f2} lv.");
        }
    }
}
