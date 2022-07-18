using System;

namespace T04.ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double ex = double.Parse(Console.ReadLine());
            int pz = int.Parse(Console.ReadLine());
            int dl = int.Parse(Console.ReadLine());
            int br = int.Parse(Console.ReadLine());
            int mn = int.Parse(Console.ReadLine());
            int tr = int.Parse(Console.ReadLine());
            int total = pz + dl + br + mn + tr;

            double prpz = pz * 2.60;
            double prdl = dl * 3;
            double prbr = br * 4.10;
            double prmn = mn * 8.20;
            double prtr = tr * 2;
            double pr = prpz + prdl + prbr + prmn + prtr;
            double rent = pr * 0.10;
            double tot = pr - rent;

            if (total >= 50)
            {
                double dis = pr - (pr * 0.25);
                rent = dis * 0.10;
                double prdis = dis - rent;

                if (prdis >= ex)
                {
                    Console.WriteLine($"Yes! {prdis - ex:F2} lv left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money! {ex - prdis:F2} lv needed.");
                }
            }
            else if (tot >= ex)
            {

                Console.WriteLine($"Yes! {tot - ex:F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {ex - tot:F2} lv needed.");
            }
        }
    }
}
