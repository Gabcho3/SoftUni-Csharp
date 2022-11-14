using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Dragon_Army
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dragons = new Dictionary<string, List<Dragon>>();
            int n = int.Parse(Console.ReadLine());

            for(int i = 0 ; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string type = data[0];
                string name = data[1];

                if (!int.TryParse(data[2], out int damage))
                    damage = 45;

                if (!int.TryParse(data[3], out int health))
                    health = 250;

                if (!int.TryParse(data[4], out int armor))
                    armor = 10;

                Dragon dragon = new Dragon()
                {
                    Name = name,
                    Damage = damage,
                    Health = health,
                    Armor = armor
                };

                if (!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new List<Dragon>());
                    dragons[type].Add(dragon);
                }

                else
                {
                    if (dragons[type].Any(x => x.Name == name))
                    {
                        for(int j = 0; j < dragons[type].Count; j++)
                        {
                            if (dragons[type][j].Name == name)
                            {
                                dragons[type][j].Damage = damage;
                                dragons[type][j].Health = health;
                                dragons[type][j].Armor = armor;
                            }
                        }
                    }

                    else
                    {
                        dragons[type].Add(dragon);
                    }
                }
            }

            foreach(var (type, currDragon) in dragons)
            {
                double averageDamage = currDragon.Average(x => x.Damage);
                double avverageHealth = currDragon.Average(x => x.Health);
                double averageArmor = currDragon.Average(x => x.Armor);
                Console.WriteLine($"{type}::({averageDamage:f2}/{avverageHealth:f2}/{averageArmor:f2})");

                foreach(var dragon in currDragon.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
        }
    }

    class Dragon
    {
        public string Name { get; set; }

        public int Damage { get; set; }


        public int Health { get; set; }


        public int Armor { get; set; }
    }
}
 