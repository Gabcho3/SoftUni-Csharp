using System;
using System.Collections.Generic;

namespace T02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var resourcesQuantity = new Dictionary<string, int>();

            while(input != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (resourcesQuantity.ContainsKey(input))
                    resourcesQuantity[input] += quantity;

                else
                    resourcesQuantity.Add(input, quantity);

                input = Console.ReadLine();
            }

            foreach(var resource in resourcesQuantity)
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
        }
    }
}
