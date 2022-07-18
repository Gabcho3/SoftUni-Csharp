using System;

namespace T03.EasterTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double price = 0;

            switch (destination)
            {
                case "France":
                    switch (dates)
                    {
                        case "21-23":
                            price = nights * 30;
                            break;
                        case "24-27":
                            price = nights * 35;
                            break;
                        case "28-31":
                            price = nights * 40;
                            break;
                    }
                    break;
                case "Italy":
                    switch (dates)
                    {
                        case "21-23":
                            price = nights * 28;
                            break;
                        case "24-27":
                            price = nights * 32;
                            break;
                        case "28-31":
                            price = nights * 39;
                            break;
                    }
                    break;
                case "Germany":
                    switch (dates)
                    {
                        case "21-23":
                            price = nights * 32;
                            break;
                        case "24-27":
                            price = nights * 37;
                            break;
                        case "28-31":
                            price = nights * 43;
                            break;
                    }
                    break;
            }
            Console.WriteLine($"Easter trip to {destination} : {price:f2} leva.");
        }
    }
}
