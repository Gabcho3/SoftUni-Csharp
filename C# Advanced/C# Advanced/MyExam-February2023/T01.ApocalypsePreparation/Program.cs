using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.ApocalypsePreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textiles = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> medicaments = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            var healingItems = new Dictionary<string, int>()
            {
                ["Patch"] = 30,
                ["Bandage"] = 40,
                ["MedKit"] = 100
            };
            var itemsCreated = new Dictionary<string, int>();

            while (textiles.Count > 0 && medicaments.Count > 0)
            {
                int sum = textiles.Dequeue() + medicaments.Peek();

                if (healingItems.Any(x => x.Value == sum))
                {
                    var item = healingItems.Where(x => x.Value == sum).First();
                    if (!itemsCreated.ContainsKey(item.Key))
                    {
                        itemsCreated.Add(item.Key, 0);
                    }
                    itemsCreated[item.Key]++;
                    medicaments.Pop();
                }

                else
                {
                    if (sum > healingItems["MedKit"])
                    {
                        if (!itemsCreated.ContainsKey("MedKit"))
                        {
                            itemsCreated.Add("MedKit", 0);
                        }
                        itemsCreated["MedKit"]++;
                        medicaments.Pop();
                        medicaments.Push(medicaments.Pop() + sum - healingItems["MedKit"]);
                    }

                    else
                    {
                        medicaments.Push(medicaments.Pop() + 10);
                    }
                }
            }

            Console.WriteLine(textiles.Count == 0 && medicaments.Count > 0 ? "Textiles are empty." 
                : textiles.Count > 0 && medicaments.Count == 0 ? "Medicaments are empty." 
                : "Textiles and medicaments are both empty.");
            PrintCreatedItems(itemsCreated);
            PrintRemainingItems(textiles, medicaments);
        }

        private static void PrintRemainingItems(Queue<int> textiles, Stack<int> medicaments)
        {
            if (medicaments.Count > 0)
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }

            if (textiles.Count > 0)
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }
        }

        private static void PrintCreatedItems(Dictionary<string, int> itemsCreated)
        {
            foreach(var (item, amount) in itemsCreated.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item} - {amount}");
            }
        }
    }
}
