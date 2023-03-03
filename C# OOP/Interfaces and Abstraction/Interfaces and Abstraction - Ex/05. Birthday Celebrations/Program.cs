using _04.BorderControl;
using PersonInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05.Birthday
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> entities = new List<IBirthable>();

            while(true)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "End")
                {
                    break;
                }

                string name = data[1];
                string birthdate = data.Last();
                switch(data[0])
                {
                    case "Citizen":
                        int age = int.Parse(data[2]);
                        string id = data[3];
                        entities.Add(new Citizen(name, age, id, birthdate));
                        break;

                    case "Pet":
                        entities.Add(new Pet(name, birthdate));
                        break;
                }
            }

            string birthYear = Console.ReadLine();
            Console.WriteLine(string.Join(Environment.NewLine, entities.Select(x => x.Birthdate).Where(x => x.EndsWith(birthYear))));
        }
    }
}
