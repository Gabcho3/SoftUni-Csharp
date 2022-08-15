using System;

namespace T07.HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double priceApartament = 0;
            double priceStudio = 0; 

            switch(month)
            {
                case "May":
                case "October":
                    priceApartament = nights * 65;
                    priceStudio = nights * 50;
                    if(nights > 7 && nights <= 14)
                    {
                        priceStudio -= priceStudio * 0.05; 
                    }
                    if(nights > 14)
                    {
                        priceApartament -= priceApartament * 0.10;
                        priceStudio -= priceStudio * 0.30;
                    }
                    break;
                case "June":
                case "September":
                    priceApartament = nights * 68.70;
                    priceStudio = nights * 75.20;
                    if (nights > 14)
                    {
                        priceApartament -= priceApartament * 0.10;
                        priceStudio -= priceStudio * 0.20;
                    }
                    break;
                case "July":
                case "August":
                    priceApartament = nights * 77;
                    priceStudio = nights * 76;
                    if (nights > 14)
                    {
                        priceApartament -= priceApartament * 0.10;
                    }
                    break;
            }
            Console.WriteLine($"Apartment: {priceApartament:F2} lv.");
            Console.WriteLine($"Studio: {priceStudio:F2} lv.");
        }
    }
}
