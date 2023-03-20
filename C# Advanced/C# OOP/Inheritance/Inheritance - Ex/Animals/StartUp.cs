using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input;
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                input = Console.ReadLine();
                if (input == "Beast!")
                    break;

                string animal = input;
                string[] data = Console.ReadLine().Split();

                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = data[2];

                if (age < 0 || (gender != "Male" && gender != "Female"))
                {
                    Console.WriteLine("Invalid input!");
                }

                else
                {
                    switch (animal)
                    {
                        case "Dog":
                            animals.Add(new Dog(name, age, gender));
                            break;

                        case "Frog":
                            animals.Add(new Frog(name, age, gender));
                            break;

                        case "Cat":
                            animals.Add(new Cat(name, age, gender));
                            break;

                        case "Kitten":
                            animals.Add(new Kitten(name, age));
                            break;

                        case "Tomcat":
                            animals.Add(new Tomcat(name, age));
                            break;
                    }
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
