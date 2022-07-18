using System;

namespace T05.Series
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bujet = double.Parse(Console.ReadLine());
            int series = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            bool noMoney = false;
            for (int serie = 1; serie <= series; serie++)
            {
                string name = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());
                switch(name)
                {
                    case "Thrones": totalPrice += price - (price * 0.50); break;
                    case "Lucifer": totalPrice += price - (price * 0.40); break;
                    case "Protector": totalPrice += price - (price * 0.30); break;
                    case "TotalDrama": totalPrice += price - (price * 0.20); break;
                    case "Area": totalPrice += price - (price * 0.10); break;
                    default:  totalPrice += price; break;
                }
                if (bujet - totalPrice < 0) noMoney = true;
            }
            if (noMoney) Console.WriteLine($"You need {totalPrice - bujet:f2} lv. more to buy the series!");
            else Console.WriteLine($"You bought all the series and left with {bujet - totalPrice:f2} lv.");
        }
    }
}
