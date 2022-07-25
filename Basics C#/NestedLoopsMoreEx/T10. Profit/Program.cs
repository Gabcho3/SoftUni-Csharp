using System;

namespace T10._Profit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int coin1Lev = int.Parse(Console.ReadLine());
            int coin2Lev = int.Parse(Console.ReadLine());
            int cash5Lev = int.Parse(Console.ReadLine());
            int profit = int.Parse(Console.ReadLine());

            for (int oneLevs = 0; oneLevs <= coin1Lev; oneLevs++)
                for(int twoLevs = 0; twoLevs <= coin2Lev; twoLevs++) 
                    for(int fiveLevs = 0; fiveLevs <= cash5Lev; fiveLevs++)
                    {
                        int sum = 5 * fiveLevs + 2 * twoLevs + 1 * oneLevs;
                        if(sum == profit)
                        {
                            Console.WriteLine("{0} * 1 lv. + {1} * 2 lv. + {2} * 5 lv. = {3} lv.", oneLevs, twoLevs, fiveLevs, profit);
                        }
                    }
        }
    }
}
