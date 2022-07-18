using System;

namespace T03.PaintingEggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string size = Console.ReadLine();
            string colour = Console.ReadLine();
            int batch = int.Parse(Console.ReadLine());
            double price = 0;
            
            switch(size)
            {
                case "Large":
                    if (colour == "Red") price = batch * 16;
                    if (colour == "Green") price = batch * 12;
                    if (colour == "Yellow") price = batch * 9;
                    break;
                case "Medium":
                    if (colour == "Red") price = batch * 13;
                    if (colour == "Green") price = batch * 9;
                    if (colour == "Yellow") price = batch * 7;
                    break;
                case "Small":
                    if (colour == "Red") price = batch * 9;
                    if (colour == "Green") price = batch * 8;
                    if (colour == "Yellow") price = batch * 5;
                    break;
            }
            price -= price * 0.35;
            Console.WriteLine($"{price:f2} leva.");
        }
    }
}
