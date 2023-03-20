using System;

namespace _09.Explicit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End")
                    return;

                string name = input[0];
                string country = input[1];
                int age = int.Parse(input[2]);

                Citizen citizen = new Citizen(name, country, age);

                Console.WriteLine((citizen as IPerson).GetName());
                Console.WriteLine((citizen as IResident).GetName());
            }
        }
    }
}
