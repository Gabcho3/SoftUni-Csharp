using System;

namespace T03.OscarsWeekInCinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string type = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());
            double price = 0;
            switch(name)
            {
                case "A Star Is Born": 
                    switch(type)
                    {
                        case "normal": price = 7.50 * tickets; break;
                        case "luxury": price = 10.50 * tickets; break;
                        case "ultra luxury": price = 13.50 * tickets; break;
                    }
                    break;
                case "Bohemian Rhapsody":
                    switch (type)
                    {
                        case "normal": price = 7.35 * tickets; break;
                        case "luxury": price = 9.45 * tickets; break;
                        case "ultra luxury": price = 12.75 * tickets; break;
                    }
                    break;
                case "Green Book":
                    switch (type)
                    {
                        case "normal": price = 8.15 * tickets; break;
                        case "luxury": price = 10.25 * tickets; break;
                        case "ultra luxury": price = 13.25 * tickets; break;
                    }
                    break;
                case "The Favourite":
                    switch (type)
                    {
                        case "normal": price = 8.75 * tickets; break;
                        case "luxury": price = 11.55 * tickets; break;
                        case "ultra luxury": price = 13.95 * tickets; break;
                    }
                    break;
            }
            Console.WriteLine($"{name} -> {price:f2} lv.");
        }
    }
}
