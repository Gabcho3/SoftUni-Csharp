using System;
using System.Collections.Generic;
using System.Linq;

namespace Training
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textile = new Queue<int>(Console.ReadLine().Split(" ",
                StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> medicaments = new Stack<int>(Console.ReadLine().Split(" ",
                StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            Dictionary<string, int> healings = new Dictionary<string, int>()
            {
                {"Patch", 30 },
                {"Bandage", 40 },
                {"MedKit", 100 }
            };

            Dictionary<string, int> itemsCreated = new Dictionary<string, int>();
            while (textile.Count > 0 && medicaments.Count > 0)
            {
                int currTextile = textile.Dequeue();
                int currMedicament = medicaments.Peek();
                int sum = currTextile + currMedicament;

                KeyValuePair<string, int> currhealing = healings.FirstOrDefault(x => x.Value == sum);

                if (currhealing.Key != null)
                {
                    itemsCreated = AddItem(currhealing.Key, itemsCreated);
                    medicaments.Pop();
                }

                else
                {
                    int medKitValue = healings.FirstOrDefault(x => x.Key == "MedKit").Value;
                    if (sum > medKitValue)
                    {
                        itemsCreated = AddItem("MedKit", itemsCreated);
                        int remainingResource = sum - medKitValue;
                        medicaments.Pop();
                        medicaments.Push(medicaments.Pop() + remainingResource);
                    }

                    else
                    {
                        medicaments.Push(medicaments.Pop() + 10);
                    }
                }
            }
            Console.WriteLine(medicaments.Count == 0 && textile.Count > 0 ? "Medicaments are empty."
                : medicaments.Count > 0 && textile.Count == 0 ? "Textiles are empty."
                : "Textiles and medicaments are both empty.");

            foreach (var (item, amount) in itemsCreated.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(item + " - " + amount);
            }

            if (medicaments.Count > 0)
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }

            if (textile.Count > 0)
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textile)}");
            }
        }

        public static Dictionary<string, int> AddItem(string key, Dictionary<string, int> itemsCreated)
        {
            if (!itemsCreated.ContainsKey(key))
            {
                itemsCreated.Add(key, 0);
            }
            itemsCreated[key]++;

            return itemsCreated;
        }
    }
}