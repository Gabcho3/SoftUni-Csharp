using System;
using System.Collections.Generic;
using System.Linq;

namespace T11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceBullet = int.Parse(Console.ReadLine());
            int gunBarelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> locks = Console.ReadLine().Split().Select(int.Parse).ToList();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Stack<int> stackBullets = new Stack<int>(bullets);

            int shoots = 0;
            int index = 0;

            while (stackBullets.Count > 0 && locks.Count > 0)
            {
                int currBullet = stackBullets.Peek();
                int currLock = locks[index];

                if (currBullet <= currLock)
                {
                    Console.WriteLine("Bang!");
                    locks.RemoveAt(index);
                }

                else
                    Console.WriteLine("Ping!");

                stackBullets.Pop();
                shoots++;

                if(shoots % gunBarelSize == 0 && stackBullets.Count > 0)
                    Console.WriteLine("Reloading!");
            }

            if(stackBullets.Count == 0 && locks.Count > 0)
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");

            if (locks.Count == 0)
                Console.WriteLine(
                    $"{stackBullets.Count} bullets left. Earned ${valueOfIntelligence - shoots * priceBullet}");
        }
    }
}
