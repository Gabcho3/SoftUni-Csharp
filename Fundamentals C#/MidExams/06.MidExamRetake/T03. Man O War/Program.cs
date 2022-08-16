using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Man_O_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split('>').Select(int.Parse).ToList();
            List<int> warShip = Console.ReadLine().Split('>').Select(int.Parse).ToList();
            int maxHealth = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "Retire")
            {
                switch(command[0])
                {
                    case "Fire":
                        Fire(warShip, command);

                        if (int.Parse(command[1]) >= 0 && int.Parse(command[1]) <= warShip.Count - 1)
                        {
                            if (warShip[int.Parse(command[1])] <= 0)
                            {
                                return;
                            }
                        }
                            break;

                    case "Defend":
                        Defend(pirateShip, command);

                        foreach (int num in pirateShip)
                        {
                            if (num <= 0)
                                return;
                        }
                        break;

                    case "Repair":
                        Repair(pirateShip, maxHealth, command);
                        break;

                    case "Status":
                        Status(pirateShip, maxHealth, command);
                        break;
                }

                command = Console.ReadLine().Split().ToArray();
            }

            Console.WriteLine($"Pirate ship status: {ReturnPirateShipSum(pirateShip)}");
            Console.WriteLine($"Warship status: {ReturnWarShipSum(warShip)}");
        }
        
        static void Fire(List<int> warShip, string[] command)
        {
            //Pirate Ship attacks
            int index = int.Parse(command[1]);
            int damage = int.Parse(command[2]);

            if(index >= 0 && index <= warShip.Count - 1)
            {
                warShip[index] -= damage;

                if (warShip[index] <= 0)
                    Console.WriteLine("You won! The enemy ship has sunken.");
            }

        }

        static void Defend(List<int> pirateShip, string[] command)
        {
            //War Ship attacks
            int startIndex = int.Parse(command[1]);
            int endIndex = int.Parse(command[2]);
            int damage = int.Parse(command[3]);

            if(startIndex >= 0 && startIndex <= pirateShip.Count - 1 &&
               endIndex >= 0 && endIndex <= pirateShip.Count - 1)
            {
                for(int i = startIndex; i <= endIndex; i++)
                {
                    pirateShip[i] -= damage;

                    if (pirateShip[i] <= 0)
                    {
                        Console.WriteLine("You lost! The pirate ship has sunken.");
                        return;
                    }
                }
            }
        }

        static void Repair(List<int> pirateShip, int maxHealth, string[] command)
        {
            int index = int.Parse(command[1]);
            int health = int.Parse(command[2]);

            if(index >= 0 && index <= pirateShip.Count - 1)
            {
                pirateShip[index] += health;

                if (pirateShip[index] > maxHealth)
                    pirateShip[index] = maxHealth;
            }
        }

        static void Status(List<int> pirateShip, int maxHealth, string[] command)
        {
            int count = 0;

            for(int i = 0; i < pirateShip.Count; i++)
            {
                if (pirateShip[i] < maxHealth * 0.2)
                    count++;
            }

            Console.WriteLine($"{count} sections need repair.");
        }

        static int ReturnPirateShipSum(List<int> pirateShip)
        {
            int sum = 0;

            foreach (int num in pirateShip)
                sum += num;

            return sum;
        }

        static int ReturnWarShipSum(List<int> warShip)
        {
            int sum = 0;

            foreach (int num in warShip)
                sum += num;

            return sum;
        }
    }
}
