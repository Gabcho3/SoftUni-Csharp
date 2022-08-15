using System;

namespace T07.Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bj = double.Parse(Console.ReadLine());
            int vc = int.Parse(Console.ReadLine());
            int pr = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());

            double sumvc = vc * 250;
            double sumpr = pr * (sumvc * 0.35);
            double sumram = ram * (sumvc * 0.10);
            double totalsum = sumvc + sumpr + sumram;

            if (vc > pr)
            {
                double dis = totalsum - (totalsum * 0.15);

                if (dis <= bj)
                {
                    Console.WriteLine($"You have {bj - dis:F2} leva left!");
                }
                else if (dis > bj)
                {
                    Console.WriteLine($"Not enough money! You need {dis - bj:F2} leva more!");

                }
            }
            else if (totalsum <= bj)
            {
                Console.WriteLine($"You have {bj - totalsum:F2} leva left!");
            }
            else if (totalsum > bj)
            {
                Console.WriteLine($"Not enough money! You need {totalsum - bj:F2} leva more!");
            }
        }
    }
}
