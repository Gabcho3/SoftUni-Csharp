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

            for(int i = 0; i < sequense.Count; i++)
            {
                if(sequense[i] == bombAndPower[0])
                {
                    int indexOfBomb = i; 
                    for(int j = 1; j <= bombAndPower[1]; j++)
                    {
                        if (indexOfBomb - j >= 0)
                            sequense.RemoveAt(i - j);

                        indexOfBomb--; //sequence.Count decrease with 1

                        if (indexOfBomb + j <= sequense.Count - 1)
                            sequense.RemoveAt(indexOfBomb + j);

                    }
                }
            }
            sequense.RemoveAll(num => num == bombAndPower[0]);

            Console.WriteLine(sequense.Sum());
        }
    }
}
