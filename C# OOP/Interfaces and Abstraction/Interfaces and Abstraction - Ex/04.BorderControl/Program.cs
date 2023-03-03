using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> entities = new List<IIdentifiable>();
            while (true)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "End")
                {
                    break;
                }

                string name = data[0];
                string id = data.Last();
                if (data.Length == 2)
                {
                    entities.Add(new Robot(name, id));
                }

                if (data.Length == 3)
                {
                    int age = int.Parse(data[1]);
                    entities.Add(new Citizen(name, age, id));
                }
            }

            string lastDigits = Console.ReadLine();
            Console.WriteLine(string.Join(Environment.NewLine, entities.Select(x => x.Id).Where(x => x.EndsWith(lastDigits))));
        }
    }
}
