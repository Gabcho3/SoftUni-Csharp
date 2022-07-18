using System;

namespace T03.Logistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cargos = int.Parse(Console.ReadLine());
            int microbus = 0;
            int truck = 0;
            int train = 0;
            double priceMicrobus = 0.00;
            double priceTruck = 0.00;
            double priceTrain = 0.00;

            for(int cargo = 1; cargo <= cargos; cargo++)
            {
                int tonnage = int.Parse(Console.ReadLine());
                if(tonnage < 4)
                {
                    microbus += tonnage;
                    priceMicrobus += tonnage * 200;
                }
                if(tonnage > 3 && tonnage < 12)
                {
                    truck += tonnage;
                    priceTruck += tonnage * 175;
                }
                if(tonnage > 11)
                {
                    train += tonnage;
                    priceTrain += tonnage * 120;
                }
            }
            double total = microbus + truck + train;
            double totalPrice = priceMicrobus + priceTruck + priceTrain;

            double averageMicrobus = microbus / total * 100;
            double averageTruck = truck / total * 100;
            double averageTrain = train / total * 100;

            Console.WriteLine($"{totalPrice / total:F2}");
            Console.WriteLine($"{averageMicrobus:F2}%");
            Console.WriteLine($"{averageTruck:F2}%"); 
            Console.WriteLine($"{averageTrain:F2}%");
        }
    }
}
