using System;

namespace T01.AgencyProfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string company = Console.ReadLine();
            int ticketAdults = int.Parse(Console.ReadLine());
            int ticketsKids = int.Parse(Console.ReadLine());
            double priceAdult = double.Parse(Console.ReadLine());
            double priceService = double.Parse(Console.ReadLine());

            double priceKid = priceAdult - (priceAdult * 0.70);
            double priceWithServiceAdult = priceAdult + priceService;
            double priceWithServiceKid = priceKid + priceService;
            double total = (priceWithServiceKid * ticketsKids) + (priceWithServiceAdult * ticketAdults);
            double profit = total * 0.20;
            Console.WriteLine($"The profit of your agency from {company} tickets is {profit:f2} lv.");
        }
    }
}
