using _04.BorderControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < lines; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = data[0];
                int age = int.Parse(data[1]);

                if (data.Length == 3)
                {
                    buyers.Add(new Rebel(name, age, data[2]));
                }

                else
                {
                    buyers.Add(new Citizen(name, age, data[2], data[3]));
                }
            }

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "End")
                {
                    Console.WriteLine(buyers.Select(x => x.Food).Sum());
                    return;
                }

                if (buyers.Any(x => x.Name == name))
                {
                    var buyer = buyers.Find(x => x.Name == name);
                    buyer.BuyFood();
                }
            }
        }
    }
}
