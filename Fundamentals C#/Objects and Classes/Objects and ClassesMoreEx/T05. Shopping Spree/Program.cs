using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace T05._Shopping_Spree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] info = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            //Adding all people
            for(int i = 0; i < info.Length; i++)
            {
                var peroson = new Person();
                int indexOfSymbol = 100; //symbol -> '='
                string money = string.Empty;

                for(int j = 0; j < info[i].Length; j++)
                {
                    string infoToString = info[i].ToString();

                    if (j < indexOfSymbol && infoToString[j] != '=')
                        peroson.Name += infoToString[j];

                    else if (infoToString[j] == '=')
                        indexOfSymbol = j;

                    else
                        money += infoToString[j];
                }

                peroson.Money = int.Parse(money);
                peroson.Bag = new List<string>();
                people.Add(peroson);
            }

            info = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            //Adding all products
            for (int i = 0; i < info.Length; i++)
            {
                var product = new Product();
                int indexOfSymbol = 100; //symbol -> '='
                string cost = string.Empty;

                for (int j = 0; j < info[i].Length; j++)
                {
                    string infoToString = info[i].ToString();

                    if (j < indexOfSymbol && infoToString[j] != '=')
                        product.Name += infoToString[j];

                    else if (infoToString[j] == '=')
                        indexOfSymbol = j;

                    else
                        cost += infoToString[j];
                }

                product.Cost = int.Parse(cost);

                products.Add(product);
            }

            string[] command = Console.ReadLine().Split();

            //Check if each person can buy a product
            while (command[0] != "END")
            {
                string name = command[0];
                string product = command[1];

                for(int i = 0; i < people.Count; i++)
                {
                    if (people[i].Name == name)
                    {
                        for (int j = 0; j < products.Count; j++)
                        {
                            if (people[i].Name == name && products[j].Name == product && products[j].Cost > people[i].Money)
                                Console.WriteLine($"{name} can't afford {product}");

                            if (people[i].Name == name && products[j].Name == product && products[j].Cost <= people[i].Money)
                            {
                                people[i].Bag.Add(product);
                                people[i].Money -= products[j].Cost;

                                Console.WriteLine($"{name} bought {product}");
                            }
                        }
                    }
                }

                command = Console.ReadLine().Split();
            }

            //Printing output
            foreach (var person in people)
            {
                if (person.Bag.Count > 0)
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");


                if (person.Bag.Count == 0)
                    Console.WriteLine($"{person.Name} - Nothing bought");
            }
        }
    }

    class Person
    {
        public string Name { get; set; }

        public int Money { get; set; }

        public List<string> Bag { get; set; }
    }

    class Product
    {
        public string Name { get; set; }

        public int Cost { get; set; }
    }
}
