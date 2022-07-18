using System;

namespace T03.MovieDestination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double filmBujet = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double price = 0;

            switch(destination)
            {
                case "Dubai":
                    switch(season)
                    {
                        case "Winter": price = days * 45000; break;
                        case "Summer": price = days * 40000; break;
                    }
                    price -= price * 0.30;
                    break;

                case "Sofia":
                    switch (season)
                    {
                        case "Winter": price = days * 17000; break;
                        case "Summer": price = days * 12500; break;
                    }
                    price += price * 0.25;
                    break;

                case "London":
                    switch (season)
                    {
                        case "Winter": price = days * 24000; break;
                        case "Summer": price = days * 20250; break;
                    }
                    break;
            }

            if (price <= filmBujet) Console.WriteLine($"The budget for the movie is enough! We have {filmBujet - price:f2} leva left!");
            else Console.WriteLine($"The director needs {price - filmBujet:f2} leva more!");
        }
    }
}


