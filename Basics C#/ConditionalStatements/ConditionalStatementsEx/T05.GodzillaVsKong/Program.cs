using System;

namespace T05.GodzillaVsKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bj = double.Parse(Console.ReadLine()); //бюджет
            int st = int.Parse(Console.ReadLine()); //брой статисти
            double clp1 = double.Parse(Console.ReadLine()); //Цена за облекло на един статист 

            double dec = bj * 0.10; //декор
            double sumcl = st * clp1; //цена облекло
            double total = sumcl + dec; //обща сума
            if (st > 150)
            {
                sumcl -= sumcl * 0.10;
                total = sumcl + dec;
                if (total <= bj)
                {
                    Console.WriteLine($"Action!");
                    Console.WriteLine($"Wingard starts filming with {bj - total:F2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money!");
                    Console.WriteLine($"Wingard needs {total - bj:F2} leva more.");
                }
            }
            else if (total > bj)
            {
                Console.WriteLine($"Not enough money!");
                Console.WriteLine($"Wingard needs {total - bj:F2} leva more.");
            }
            else if (total <= bj)
            {
                Console.WriteLine($"Action!");
                Console.WriteLine($"Wingard starts filming with {bj - total:F2} leva left.");
            }
        }
    }
}
