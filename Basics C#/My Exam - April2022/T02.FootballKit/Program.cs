using System;

namespace T02.FootballKit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceShirt = double.Parse(Console.ReadLine());
            double neededSum = double.Parse(Console.ReadLine());

            double priceShorts = priceShirt * 0.75;
            double priceSocks = priceShorts * 0.20;
            double priceButtons = (priceShirt + priceShorts) * 2;
            double totalSum = priceShirt + priceShorts + priceSocks + priceButtons;
            double sumAfterDiscount = totalSum - (totalSum * 0.15);
            if (sumAfterDiscount >= neededSum)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {sumAfterDiscount:f2} lv.");
            }
            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball."); 
                Console.WriteLine($"He needs {neededSum - sumAfterDiscount:f2} lv. more.");
            }
        }
    }
}
