using System;

namespace T03.AluminumJoinery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberDograms = int.Parse(Console.ReadLine());
            string typeDograms = Console.ReadLine();
            string typeReceive = Console.ReadLine();
            double price = 0;
            bool invalid = false;
            if (numberDograms < 10) invalid = false;
            if (numberDograms > 10) invalid = true;

            switch(typeDograms)
            {
                case "90X130":
                    price = 110;
                    if (numberDograms > 30 && numberDograms <= 60) price -= price * 0.05;
                    if (numberDograms > 60) price -= price * 0.08;
                    break;
                case "100X150":
                    price = 140;
                    if (numberDograms > 40 && numberDograms <= 80) price -= price * 0.06;
                    if (numberDograms > 80) price -= price * 0.10;
                    break;
                case "130X180":
                    price = 190;
                    if (numberDograms > 20 && numberDograms <= 50) price -= price * 0.07;
                    if (numberDograms > 50) price -= price * 0.12; 
                    break;
                case "200X300":
                    price = 250;
                    if (numberDograms > 25 && numberDograms <= 50) price -= price * 0.09;
                    if (numberDograms > 50) price -= price * 0.14; 
                    break;
            }
            price *= numberDograms;
            if (typeReceive == "With delivery" && invalid == true)
            {
                price += 60;
            }
            
            if (numberDograms > 99) price -= price * 0.04;
            if (invalid == false) Console.WriteLine("Invalid order");
            if(invalid == true) Console.WriteLine($"{price:F2} BGN");
        }
    }
}
