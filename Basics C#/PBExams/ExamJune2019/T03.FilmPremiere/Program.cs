using System;

namespace T03.FilmPremiere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            string packetFilm = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());
            double price = 0;
            switch(projection)
            {
                case "John Wick":
                    switch(packetFilm)
                    {
                        case "Drink": price = tickets * 12.0; break;
                        case "Popcorn": price = tickets * 15.0; break;
                        case "Menu": price = tickets * 19.0; break;
                    }
                    break;

                case "Star Wars":
                    switch (packetFilm)
                    {
                        case "Drink": price = tickets * 18.0; break;
                        case "Popcorn": price = tickets * 25.0; break;
                        case "Menu": price = tickets * 30.0; break;
                    }
                    if (tickets >= 4) price -= price * 0.30;
                    break;

                case "Jumanji":
                    switch (packetFilm)
                    {
                        case "Drink": price = tickets * 9.0; break;
                        case "Popcorn": price = tickets * 11.0; break;
                        case "Menu": price = tickets * 14.0; break;
                    }
                    if (tickets == 2) price -= price * 0.15;        
                    break;
            }
            Console.WriteLine($"Your bill is {price:f2} leva.");
        }
    }
}

