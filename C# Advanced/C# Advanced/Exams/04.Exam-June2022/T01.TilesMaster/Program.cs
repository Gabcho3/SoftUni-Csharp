using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Queue<int> greyTiles = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Dictionary<string, int> locationAreas = new Dictionary<string, int>()
            {
                ["Sink"] = 40,
                ["Oven"] = 50,
                ["Countertop"] = 60,
                ["Wall"] = 70
            };

            Dictionary<string, int> locationAmounts = new Dictionary<string, int>();

            while (true)
            {
                if (whiteTiles.Peek() == greyTiles.Peek())
                {
                    int area = whiteTiles.Peek() * 2;
                    bool haveMatch = false;
                    foreach (var (location, areaNeeded) in locationAreas)
                    {
                        if (area == areaNeeded)
                        {
                            if (!locationAmounts.ContainsKey(location))
                            {
                                locationAmounts.Add(location, 0);
                            }
                            locationAmounts[location]++;
                            haveMatch = true;
                            break;
                        }
                    }

                    if (!haveMatch)
                    {
                        if (!locationAmounts.ContainsKey("Floor"))
                        {
                            locationAmounts.Add("Floor", 0);
                        }
                        locationAmounts["Floor"]++;
                    }

                    whiteTiles.Pop();
                    greyTiles.Dequeue();
                }

                else
                {
                    whiteTiles.Push(whiteTiles.Pop() / 2);
                    greyTiles.Enqueue(greyTiles.Dequeue());
                }

                if (whiteTiles.Count() == 0 || greyTiles.Count() == 0)
                    break;
            }

            Console.WriteLine(whiteTiles.Count > 0 ? $"White tiles left: {string.Join(", ", whiteTiles)}" : "White tiles left: none");
            Console.WriteLine(greyTiles.Count > 0 ? $"Grey tiles left: {string.Join(", ", greyTiles)}" : "Grey tiles left: none");
            foreach (var (location, amount) in locationAmounts.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{location}: {amount}");
            }
        }
    }
}
