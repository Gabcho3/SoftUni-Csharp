using System;

namespace T03.WorldSnookerChampionship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string round = Console.ReadLine(); //Quarter final, Semi Final, Final
            string type = Console.ReadLine(); //Standard, Premium, VIP
            int tickets = int.Parse(Console.ReadLine()); //number of tickets
            string photo = Console.ReadLine(); //Yes or No

            double price = 0;

            switch(round)
            {
                case "Quarter final":
                    if(type == "Standard")
                    {
                        price = 55.50 * tickets;
                        switch(photo)
                        {
                            case "Y":
                                if (price <= 2500) price += tickets * 40;
                                if (price > 2500 && price <= 4000) price = price - (price * 0.10) + (tickets * 40);
                                if (price > 4000) price -= price * 0.25;
                                break;
                            case "N":
                                if (price > 2500 && price <= 4000) price -= price * 0.10;
                                if (price > 4000) price -= price * 0.25;
                                break;
                        }
                    }
                    if(type == "Premium")
                    {
                        price = 105.20 * tickets;
                        switch (photo)
                        {
                            case "Y":
                                if (price <= 2500) price += tickets * 40;
                                if (price > 2500 && price <= 4000) price = price - (price * 0.10) + (tickets * 40);
                                if (price > 4000) price -= price * 0.25;
                                break;
                            case "N":
                                if (price > 2500 && price <= 4000) price -= price * 0.10;
                                if (price > 4000) price -= price * 0.25;
                                break;
                        }
                    }
                    if(type == "VIP")
                    {
                        price = 118.90 * tickets;
                        switch (photo)
                        {
                            case "Y":
                                if (price <= 2500) price += tickets * 40;
                                if (price > 2500 && price <= 4000) price = price - (price * 0.10) + (tickets * 40);
                                if (price > 4000) price -= price * 0.25;
                                break;
                            case "N":
                                if (price > 2500 && price <= 4000) price -= price * 0.10;
                                if (price > 4000) price -= price * 0.25;
                                break;
                        }
                    }
                    break;
                case "Semi final":
                    if (type == "Standard")
                    {
                        price = 75.88 * tickets;
                        switch (photo)
                        {
                            case "Y":
                                if (price <= 2500) price += tickets * 40;
                                if (price > 2500 && price <= 4000) price = price - (price * 0.10) + (tickets * 40);
                                if (price > 4000) price -= price * 0.25;
                                break;
                            case "N":
                                if (price > 2500 && price <= 4000) price -= price * 0.10;
                                if (price > 4000) price -= price * 0.25;
                                break;
                        }
                    }
                    if (type == "Premium")
                    {
                        price = 125.22 * tickets;
                        switch (photo)
                        {
                            case "Y":
                                if (price <= 2500) price += tickets * 40;
                                if (price > 2500 && price <= 4000) price = price - (price * 0.10) + (tickets * 40);
                                if (price > 4000) price -= price * 0.25;
                                break;
                            case "N":
                                if (price > 2500 && price <= 4000) price -= price * 0.10;
                                if (price > 4000) price -= price * 0.25;
                                break;
                        }
                    }
                    if (type == "VIP")
                    {
                        price = 300.40 * tickets;
                        switch (photo)
                        {
                            case "Y":
                                if (price <= 2500) price += tickets * 40;
                                if (price > 2500 && price <= 4000) price = price - (price * 0.10) + (tickets * 40);
                                if (price > 4000) price -= price * 0.25;
                                break;
                            case "N":
                                if (price > 2500 && price <= 4000) price -= price * 0.10;
                                if (price > 4000) price -= price * 0.25;
                                break;
                        }
                    }
                    break;
                case "Final":
                    if (type == "Standard")
                    {
                        price = 110.10 * tickets;
                        switch (photo)
                        {
                            case "Y":
                                if (price <= 2500) price += tickets * 40;
                                if (price > 2500 && price <= 4000) price = price - (price * 0.10) + (tickets * 40);
                                if (price > 4000) price -= price * 0.25;
                                break;
                            case "N":
                                if (price > 2500 && price <= 4000) price -= price * 0.10;
                                if (price > 4000) price -= price * 0.25;
                                break;
                        }
                    }
                    if (type == "Premium")
                    {
                        price = 160.66 * tickets;
                        switch (photo)
                        {
                            case "Y":
                                if (price <= 2500) price += tickets * 40;
                                if (price > 2500 && price <= 4000) price = price - (price * 0.10) + (tickets * 40);
                                if (price > 4000) price -= price * 0.25;
                                break;
                            case "N":
                                if (price > 2500 && price <= 4000) price -= price * 0.10;
                                if (price > 4000) price -= price * 0.25;
                                break;
                        }
                    }
                    if (type == "VIP")
                    {
                        price = 400.00 * tickets;
                        switch (photo)
                        {
                            case "Y":
                                if (price <= 2500) price += tickets * 40;
                                if (price > 2500 && price <= 4000) price = price - (price * 0.10) + (tickets * 40);
                                if (price > 4000) price -= price * 0.25;
                                break;
                            case "N":
                                if (price > 2500 && price <= 4000) price -= price * 0.10;
                                if (price > 4000) price -= price * 0.25;
                                break;
                        }
                    }
                    break;
            }
            Console.WriteLine($"{price:f2}");
        }
    }
}
