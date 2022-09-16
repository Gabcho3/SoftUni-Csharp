using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(" <:> ");

            var dwarfsData = new Dictionary<string, Dictionary<string, int>>();

            while (data[0] != "Once upon a time")
            {
                string name = data[0];
                string color = data[1];
                int physics = int.Parse(data[2]);

                if(dwarfsData.ContainsKey(name) && dwarfsData[name].ContainsKey(color))
                {
                    if (dwarfsData[name][color] < physics)
                        dwarfsData[name][color] = physics;
                }

                else if (dwarfsData.ContainsKey(name))
                {
                    dwarfsData[name].Add(color, physics);
                }

                else
                {
                    dwarfsData.Add(name, new Dictionary<string, int>());
                    dwarfsData[name].Add(color, physics);
                }

                data = Console.ReadLine().Split(" <:> ");
            }
        }
    }
}
