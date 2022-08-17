using System;
using System.Linq;

namespace Т02._MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split("|").ToArray();

            int health = 100;
            int bitcoins = 0;

            for(int i = 0; i < rooms.Length; i++)
            {
                string[] command = rooms[i].Split();

                switch(command[0])
                {
                    case "potion":
                        health = Potion(health, command);
                        break;

                    case "chest":
                        bitcoins = Chest(bitcoins, command);
                        break;

                    default:
                        health = Attack(health, command, i);
                        break;
                }

                if (health <= 0)
                    return;
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");

        }

        static int Potion(int health, string[] command)
        {
            int amount = 0;

            while(health < 100 && int.Parse(command[1]) != amount)
            {
                health++;
                amount++;
            }

            Console.WriteLine($"You healed for {amount} hp.");
            Console.WriteLine($"Current health: {health} hp.");

            return health;
        }

        static int Chest(int bitcoins, string[] command)
        {
            int amountBitcoins = int.Parse(command[1]);
            bitcoins += amountBitcoins;

            Console.WriteLine($"You found {amountBitcoins} bitcoins.");

            return bitcoins;
        }

        static int Attack(int health, string[] command, int room)
        {
            string monster = command[0];
            int monsterAttack = int.Parse(command[1]);

            health -= monsterAttack;

            if (health > 0)
                Console.WriteLine($"You slayed {monster}.");

            else
            {
                Console.WriteLine($"You died! Killed by {monster}.");
                Console.WriteLine($"Best room: {room + 1}");
            }

            return health;
        }
    }
}
