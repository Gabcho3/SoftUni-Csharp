using System;

namespace T02.Safari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bujet = double.Parse(Console.ReadLine());
            double liters = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            double price = 0;

            double pricePetrol = liters * 2.10;
            price = pricePetrol + 100;
            switch(day)
            {
                case "Saturday": price -= price * 0.10;
                    break;
                case "Sunday": price -= price * 0.20;
                    break;
            }
            if (price > bujet)  Console.WriteLine($"Not enough money! Money needed: {price - bujet:f2} lv.");
            else Console.WriteLine($"Safari time! Money left: {bujet - price:f2} lv.");
        }
    }
}
