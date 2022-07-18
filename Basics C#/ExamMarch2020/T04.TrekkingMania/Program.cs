using System;

namespace T04.TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            int Mussala = 0;
            int MontBlanc = 0;
            int Kalimanjaro = 0;
            int K2 = 0;
            int Everest = 0;

            for(int everyGroup = 1; everyGroup <= groups; everyGroup++)
            {
                int people = int.Parse(Console.ReadLine());
                if(people <= 5)
                {
                    Mussala += people;
                }
                if(people >= 6 && people <= 12)
                {
                    MontBlanc += people;
                }
                if(people >= 13 && people <= 25)
                {
                    Kalimanjaro += people;
                }
                if(people >= 26 && people <= 40)
                {
                    K2 += people;
                }
                if(people >= 41)
                {
                    Everest += people;
                }
            }
            double total = Mussala + MontBlanc + Kalimanjaro + K2 + Everest;
            double percentMussala = Mussala / total * 100;
            double percentMontBlanc = MontBlanc / total * 100;
            double percentKalimanjaro = Kalimanjaro / total * 100;
            double percentK2 = K2 / total * 100;
            double persentEverest = Everest / total * 100;
            Console.WriteLine($"{percentMussala:f2}%");
            Console.WriteLine($"{percentMontBlanc:f2}%");
            Console.WriteLine($"{percentKalimanjaro:f2}%");
            Console.WriteLine($"{percentK2:f2}%");
            Console.WriteLine($"{persentEverest:f2}%");
        }
    }
}
