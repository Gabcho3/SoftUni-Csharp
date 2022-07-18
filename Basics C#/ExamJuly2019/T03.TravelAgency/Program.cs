using System;

namespace T03.TravelAgency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            string packet = Console.ReadLine();
            string VIP = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double price = 0;
            if (days <= 0)
            {
                Console.WriteLine("Days must be positive number!"); 
                return;
            }
            switch(city)
            {
                case "Bansko":
                case "Borovets":
                    switch(packet)
                    {
                        case "noEquipment": price = days * 80; if (VIP == "yes") price -= price * 0.05;
                            break;
                        case "withEquipment": price = days * 100; if (VIP == "yes") price -= price * 0.10;
                            break;
                        default: Console.WriteLine("Invalid input!"); return;
                    }
                    break;
                case "Varna":
                case "Burgas":
                    switch (packet)
                    {
                        case "noBreakfast": price = days * 100; if (VIP == "yes") price -= price * 0.07;
                             break;
                        case "withBreakfast": price = days * 130; if (VIP == "yes") price -= price * 0.12;
                            break;
                        default: Console.WriteLine("Invalid input!"); return;
                    }
                    break;
                default: Console.WriteLine("Invalid input!"); return;
            }
            Console.WriteLine($"The price is {price:f2}lv! Have a nice time!");
        }
    }
}
