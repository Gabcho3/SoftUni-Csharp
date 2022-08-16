using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Treasure_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> loot = Console.ReadLine().Split("|").ToList();
            string[] action = Console.ReadLine().Split().ToArray();

            while (action[0] != "Yohoho!")
            {
                switch(action[0])
                {
                    case "Loot":
                        Loot(loot, action);
                        break;

                    case "Drop":
                        Drop(loot, action);
                        break;

                    case "Steal":
                        Steal(loot, action);
                        break;
                }

                action = Console.ReadLine().Split().ToArray();
            }

            double avarageGain = AvarageGain(loot);

            if (avarageGain > 0)
                Console.WriteLine($"Average treasure gain: {avarageGain:f2} pirate credits.");

            else
                Console.WriteLine("Failed treasure hunt.");
        }

        static void Loot(List<string> loot, string[] action)
        {
            for(int i = 1; i < action.Length; i++)
            {
                if(!loot.Contains(action[i]))
                    loot.Insert(0, action[i]);
            }
        }

        static void Drop(List<string> loot, string[] action)
        {
            int index = int.Parse(action[1]);
            
            if(index >= 0 && index <= loot.Count - 1)
            {
                string removedItem = loot[index];
                loot.Remove(removedItem);
                loot.Add(removedItem);
            }
        }
        
        static void Steal(List<string> loot, string[] action)
        {
            int count = int.Parse(action[1]);

            List<string> stolenItems = new List<string>();

            int firstIndexOfSteal = loot.Count - count;

            if (firstIndexOfSteal < 0)
                firstIndexOfSteal = 0;

            for(int i = 0; i < loot.Count; i++)
            {
                if (i >= firstIndexOfSteal)
                    stolenItems.Add(loot[i]);
            }

            loot.RemoveRange(firstIndexOfSteal, count);

            Console.WriteLine(string.Join(", ", stolenItems));
        }

        static double AvarageGain(List<string> loot)
        {
            double sum = 0;

            for(int i = 0; i < loot.Count; i++)
            {
                string currItem = loot[i];
                sum += currItem.Length;
            }
            sum /= loot.Count;

            return sum;
        }
    }
}
