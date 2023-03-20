using _04.WildFarm.Animals;
using _04.WildFarm.Animals.Birds;
using _04.WildFarm.Animals.Mammals;
using _04.WildFarm.Animals.Mammals.Felines;
using _04.WildFarm.Food;
using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            List<F> food = new List<F>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                AddAnimals(animals, animalData);

                string[] foodData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                AddFood(food, foodData);
            }

            for(int i = 0; i < food.Count; i++)
            {
                Console.WriteLine(animals[i].ProduceSound());
                animals[i].Eat(food[i]);
            }

            foreach (var animal in animals)
                Console.WriteLine(animal.ToString());
        }

        public static void AddAnimals(List<Animal> animals, string[] animalData)
        {
            string type = animalData[0];
            string name = animalData[1];
            double weight = double.Parse(animalData[2]);

            switch (type)
            {
                case "Owl":
                case "Hen":
                    double wingSize = double.Parse(animalData[3]);
                    if (type == "Owl")
                        animals.Add(new Owl(name, weight, wingSize));

                    else
                        animals.Add(new Hen(name, weight, wingSize));
                    break;

                case "Cat":
                case "Tiger":
                    string livingRegion = animalData[3];
                    string breed = animalData[4];
                    if (type == "Cat")
                        animals.Add(new Cat(name, weight, livingRegion, breed));

                    else
                        animals.Add(new Tiger(name, weight, livingRegion, breed));
                    break;

                case "Mouse":
                case "Dog":
                    livingRegion = animalData[3];
                    if (type == "Mouse")
                        animals.Add(new Mouse(name, weight, livingRegion));

                    else
                        animals.Add(new Dog(name, weight, livingRegion));
                    break;
            }
        }

        public static void AddFood(List<F> food, string[] foodData)
        {
            string foodType = foodData[0];
            int quantity = int.Parse(foodData[1]);

            switch(foodType)
            {
                case "Vegetable":
                    food.Add(new Vegetable(quantity));
                    break;

                case "Fruit":
                    food.Add(new Fruit(quantity));
                    break;

                case "Meat":
                    food.Add(new Meat(quantity));
                    break;

                case "Seeds":
                    food.Add(new Seeds(quantity));
                    break;
            }
        }
    }
}
