using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleData = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsData = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            foreach (string person in peopleData)
            {
                string[] data = person.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                decimal money = decimal.Parse(data[1]);

                try
                {
                    people.Add(new Person(name, money));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            foreach(var product in productsData.Where(x => x != string.Empty))
            {
                string[] data = product.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                decimal cost = decimal.Parse(data[1]);

                try
                {
                    products.Add(new Product(name, cost));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            while(true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "END")
                {
                    break;
                }

                string personName = command[0];
                string productName = command[1];

                Person person = people.Find(x => x.Name == personName);
                Product product = products.Find(x => x.Name == productName);

                if (person != null && product != null)
                {
                    person.AddProducts(product);
                }
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }    
        }
    }
}
