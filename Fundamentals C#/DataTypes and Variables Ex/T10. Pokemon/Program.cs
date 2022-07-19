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

            int reachedTargets = 0;

            while(powerоfPokemon >= distance) {
                powerоfPokemon -= distance;
                if (originalValue * 0.5 == powerоfPokemon) {
                    powerоfPokemon /= exhaustionFactor;
                }
                
                reachedTargets++; 
            }
            Console.WriteLine(powerоfPokemon);
            Console.WriteLine(reachedTargets);
        }
    }
}
