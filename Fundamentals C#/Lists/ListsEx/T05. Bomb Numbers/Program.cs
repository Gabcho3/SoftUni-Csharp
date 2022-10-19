using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sequense = Console.ReadLine().Split().Select(int.Parse).ToList();
            var bombAndPower = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int bomb = bombAndPower[0];
            int power = bombAndPower[1];

            int indexOfBomb = 0;

            while (sequense.Contains(bomb))
            {
                for (int i = 0; i < sequense.Count; i++)
                {
                    if (sequense[i] == bomb)
                    {
                        indexOfBomb = i;
                        break;
                    }
                }

                int startIndex = indexOfBomb - power;
                int count = 2 * power + 1;

                if (startIndex < 0)
                    startIndex = 0;

                if (count > sequense.Count - 1)
                    count = sequense.Count - startIndex;

                sequense.RemoveRange(startIndex, count);
            }

            Console.WriteLine(sequense.Sum());
        }
    }
}
