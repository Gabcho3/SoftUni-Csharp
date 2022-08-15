using System;

namespace T01.BackToThePast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moneyReceive = double.Parse(Console.ReadLine());
            int yearOfDead = int.Parse(Console.ReadLine());
            int age = 18;

            for(int year = 1800; year <= yearOfDead; year++, age++)
            {
                if(year % 2 != 0)
                {
                    moneyReceive -= 12000 + (50 * age);
                }
                else
                {
                    moneyReceive -= 12000;
                }
            }
            if(moneyReceive >= 0)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {moneyReceive:F2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {Math.Abs(moneyReceive):F2} dollars to survive.");
            }
        }
    }
}
