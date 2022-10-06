using System;

namespace T05._Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int currHealth = int.Parse(Console.ReadLine());
            int maxHealth = int.Parse(Console.ReadLine());

            int currEnergy = int.Parse(Console.ReadLine());
            int maxEnergy = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: |{new string('|', currHealth)}{new string('.', maxHealth - currHealth)}|");
            Console.WriteLine($"Energy: |{new string('|', currEnergy)}{new string('.', maxEnergy - currEnergy)}|");
        }
    }
}
