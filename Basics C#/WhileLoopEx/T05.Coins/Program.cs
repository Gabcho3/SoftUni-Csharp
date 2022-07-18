using System;

namespace T05.Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double resto = Math.Round(double.Parse(Console.ReadLine()) * 100); //lev to coins; ex. 1.23 --> 123
            int coinsCounter = 0;
            while(resto > 0)
            {
                if (resto >= 200)
                {
                    resto -= 200;
                }
                else if (resto >= 100)
                {
                    resto -= 100;
                }
                else if (resto >= 50)
                {
                    resto -= 50;
                }
                else if (resto >= 20)
                {
                    resto -= 20;
                }
                else if (resto >= 10)
                {
                    resto -= 10;
                }
                else if (resto >= 5)
                {
                    resto -= 5;
                }
                else if (resto >= 2)
                {
                    resto -= 2;
                }
                else if (resto >= 1)
                {
                    resto -= 1;
                }
                coinsCounter++;
            }
            Console.WriteLine(coinsCounter);
        }
    }
}
