using System;

namespace T03.CoffeeMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeOfDrink = Console.ReadLine();
            string sugar = Console.ReadLine();
            int drinks = int.Parse(Console.ReadLine());
            double price = 0;
            switch(typeOfDrink)
            {
                case "Espresso":
                    switch(sugar)
                    {
                        case "Without": price = drinks * 0.90; price -= price * 0.35; break;
                        case "Normal": price = drinks * 1; break;
                        case "Extra": price = drinks * 1.20;  break;
                    }
                    if (drinks >= 5) price -= price * 0.25;
                    if (price > 15) price -= price * 0.20;
                    break;
                case "Cappuccino":
                    switch (sugar)
                    {
                        case "Without": price = drinks * 1; price -= price * 0.35; break;
                        case "Normal": price = drinks * 1.20; break;
                        case "Extra": price = drinks * 1.60; break;
                    }
                    if (price > 15) price -= price * 0.20;
                    break;
                case "Tea":
                    switch (sugar)
                    {
                        case "Without": price = drinks * 0.50; price -= price * 0.35; break;
                        case "Normal": price = drinks * 0.60; break;
                        case "Extra": price = drinks * 0.70; break;
                    }
                    if (price > 15) price -= price * 0.20;
                    break;
            }
            Console.WriteLine($"You bought {drinks} cups of {typeOfDrink} for {price:f2} lv.");
        }
    }
}
