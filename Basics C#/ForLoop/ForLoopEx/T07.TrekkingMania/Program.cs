using System;

namespace T07.TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            double total = 0;
            double Musala = 0;
            double MontBlanc = 0;
            double Kalimanjaro = 0;
            double K2 = 0;
            double Everest = 0;

            for(int i = 1; i <= groups; i++)
            {
                int numberOfPeople = int.Parse(Console.ReadLine());
                total += numberOfPeople;
                if(numberOfPeople <= 5)
                {
                    Musala += numberOfPeople;
                }
                if(numberOfPeople >= 6 & numberOfPeople <= 12)
                {
                    MontBlanc += numberOfPeople;
                }
                if (numberOfPeople >= 13 & numberOfPeople <= 25)
                {
                    Kalimanjaro += numberOfPeople;
                }
                if(numberOfPeople >= 26 & numberOfPeople <= 40)
                {
                    K2 += numberOfPeople;
                }
                if(numberOfPeople >= 41)
                {
                    Everest += numberOfPeople;
                }
            }
            Console.WriteLine($"{Musala / total * 100:F2}%");
            Console.WriteLine($"{MontBlanc / total * 100:F2}%");
            Console.WriteLine($"{Kalimanjaro / total * 100:F2}%");
            Console.WriteLine($"{K2 / total * 100:F2}%");
            Console.WriteLine($"{Everest / total * 100:F2}%");
        }
    }
}
