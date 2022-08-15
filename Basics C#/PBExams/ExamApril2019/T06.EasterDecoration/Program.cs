using System;

namespace T06.EasterDecoration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int clients  = int.Parse(Console.ReadLine());
            double price = 0;
            double currentPrice = 0;
            int items = 0;

            for(int client = 1; client <= clients; client++)
            {
                string products = Console.ReadLine();
                while(products != "Finish")
                {
                    switch(products)
                    {
                        case "basket": { currentPrice += 1.50; items++; }
                            break;
                        case "wreath": { currentPrice += 3.80; items++; }
                            break;
                        case "chocolate bunny": { currentPrice += 7.00; items++; }
                            break; 
                    }
                    products = Console.ReadLine();
                }
                if (items % 2 == 0) currentPrice -= currentPrice * 0.20;
                price += currentPrice;
                Console.WriteLine($"You purchased {items} items for {currentPrice:f2} leva.");
                items = 0;
                currentPrice = 0;
            }
            double average = price / clients;
            Console.WriteLine($"Average bill per client is: {average:f2} leva.");
        }
    }
}
