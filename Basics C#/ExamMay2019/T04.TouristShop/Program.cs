using System;

namespace T04.TouristShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bujet = double.Parse(Console.ReadLine());
            string product = Console.ReadLine();
            double price = 0;
            int productsBought = 0;
            double totalAmount = 0;
            bool noMoney = false;

            while (product != "Stop")
            {
                price = double.Parse(Console.ReadLine());
                productsBought++;
                if (productsBought % 3 == 0 && productsBought != 0) price /= 2;
                bujet -= price;
                if (bujet < 0)
                {
                    bujet += price;
                    productsBought--;
                    noMoney = true;
                    break;
                }
                totalAmount += price;
                product = Console.ReadLine();
            }
            if (noMoney)
            {
                Console.WriteLine("You don't have enough money!"); Console.WriteLine($"You need {price - bujet:f2} leva!"); 
                return;
            }
            Console.WriteLine($"You bought {productsBought} products for {totalAmount:f2} leva.");
        }
    }
}
