using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace T01.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            Dictionary<string, int> swords = new Dictionary<string, int>()
            {
                ["Gladius"] = 70,
                ["Shamshir"] = 80,
                ["Katana"] = 90,
                ["Sabre"] = 110,
                ["Broadsword"] = 150
            };

            Dictionary<string, int> swordsForged = new Dictionary<string, int>();

            while(steel.Count > 0 && carbon.Count > 0) 
            {
                int sum = steel.Dequeue() + carbon.Peek();
                var sword = swords.Where(x => x.Value == sum).FirstOrDefault();

                if(sword.Key != null)
                {
                    if(!swordsForged.ContainsKey(sword.Key))
                    {
                        swordsForged.Add(sword.Key, 0);
                    }
                    swordsForged[sword.Key]++;
                    carbon.Pop();
                }

                else
                {
                    carbon.Push(carbon.Pop() + 5);
                }
            }
            Console.WriteLine(swordsForged.Count > 0 ? $"You have forged {swordsForged.Values.Sum()} swords." 
                : "You did not have enough resources to forge a sword.");
            Console.WriteLine(steel.Count > 0 ? $"Steel left: {string.Join(", ", steel)}" : "Steel left: none");
            Console.WriteLine(carbon.Count > 0 ? $"Carbon left: {string.Join(", ", carbon)}" : "Carbon left: none");

            foreach(var (sword, amount) in swordsForged.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{sword}: {amount}");
            }
        }
    }
}
