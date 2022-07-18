using System;

namespace T01._Movie_Profit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int tickets = int.Parse(Console.ReadLine());
            double priceTicket = double.Parse(Console.ReadLine());
            int precentForCinema = int.Parse(Console.ReadLine());

            double priceForDay = tickets * priceTicket;
            double totalPrice = days * priceForDay;
            double totalPriceForCinema = totalPrice * precentForCinema / 100;
            double income = totalPrice - totalPriceForCinema;
            Console.WriteLine($"The profit from the movie {name} is {income:f2} lv.");
        }
    }
}


