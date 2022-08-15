using System;

namespace T03.FitnessCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double ourSum = double.Parse(Console.ReadLine());
            string sex = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();
            double price = 0;
            
            switch(sport)
            {
                case "Gym":
                    sport = "Gym";
                    if(sex == "m")
                    {
                        price = 42;
                    }
                    if(sex == "f")
                    {
                        price = 35;
                    }
                    if(age <= 19)
                    {
                        price -= price * 0.20;
                    }
                    break;
                case "Boxing":
                    sport = "Boxing";
                    if (sex == "m")
                    {
                        price = 41;
                    }
                    if (sex == "f")
                    {
                        price = 37;
                    }
                    if (age <= 19)
                    {
                        price -= price * 0.20;
                    }
                    break;
                case "Yoga":
                    sport = "Yoga";
                    if (sex == "m")
                    {
                        price = 45;
                    }
                    if (sex == "f")
                    {
                        price = 42;
                    }
                    if (age <= 19)
                    {
                        price -= price * 0.20;
                    }
                    break;
                case "Zumba":
                    sport = "Zumba";
                    if (sex == "m")
                    {
                        price = 34;
                    }
                    if (sex == "f")
                    {
                        price = 31;
                    }
                    if (age <= 19)
                    {
                        price -= price * 0.20;
                    }
                    break;
                case "Dances":
                    sport = "Dances";
                    if (sex == "m")
                    {
                        price = 51;
                    }
                    if (sex == "f")
                    {
                        price = 53;
                    }
                    if (age <= 19)
                    {
                        price -= price * 0.20;
                    }
                    break;
                case "Pilates":
                    sport = "Pilates";
                    if (sex == "m")
                    {
                        price = 39;
                    }
                    if (sex == "f")
                    {
                        price = 37;
                    }   
                    if (age <= 19)
                    {
                        price -= price * 0.20;
                    }
                    break;
            }
            if (price < ourSum) Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            else Console.WriteLine($"You don't have enough money! You need ${price - ourSum:f2} more.");
        }
    }
}
