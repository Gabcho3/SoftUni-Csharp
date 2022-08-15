using System;

namespace T05.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bujet = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string place;
            string location;
            double price;

            if(bujet <= 1000)
            {
                place = "Camp";
                if(season == "Summer")
                {
                    location = "Alaska";
                    price = bujet * 0.65;
                    Console.WriteLine($"{location} - {place} - {price:F2}");
                }
                if(season == "Winter")
                {
                    location = "Morocco";
                    price = bujet * 0.45;
                    Console.WriteLine($"{location} - {place} - {price:F2}");
                }
            }

            if(bujet > 1000 & bujet <= 3000)
            {
                place = "Hut";
                if (season == "Summer")
                {
                    location = "Alaska";
                    price = bujet * 0.80;
                    Console.WriteLine($"{location} - {place} - {price:F2}");
                }
                if (season == "Winter")
                {
                    location = "Morocco";
                    price = bujet * 0.60;
                    Console.WriteLine($"{location} - {place} - {price:F2}");
                }
            }

            if(bujet > 3000)
            {
                place = "Hotel";
                price = bujet * 0.90;
                if (season == "Summer")
                {
                    location = "Alaska";
                    Console.WriteLine($"{location} - {place} - {price:F2}");
                }
                if (season == "Winter")
                {
                    location = "Morocco";
                    Console.WriteLine($"{location} - {place} - {price:F2}");
                }
            }
        }
    }
}
