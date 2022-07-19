using System;

namespace T10._Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int powerоfPokemon = int.Parse(Console.ReadLine());
            int originalValue = powerоfPokemon;

            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int halfOfOriginalValue = originalValue / 2;
            int reachedTargets = 0;

            while(powerоfPokemon >= distance) {
                powerоfPokemon -= distance;
                if (halfOfOriginalValue == powerоfPokemon && exhaustionFactor != 0)
                {
                    powerоfPokemon /= exhaustionFactor;
                }

                reachedTargets++; 
            }
            Console.WriteLine(powerоfPokemon);
            Console.WriteLine(reachedTargets);
        }
    }
}
