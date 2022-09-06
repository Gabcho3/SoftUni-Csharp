using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._Order_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split();

            List<Person> people = new List<Person>();
            List<int> ids = new List<int>();

            while (data[0] != "End")
            {
                Person person = new Person() { Name = data[0], Id = int.Parse(data[1]), Age = int.Parse(data[2]) };

                bool notSameId = true;

                //Check if Id is Same
                for (int i = 0; i < ids.Count; i++)
                {
                    if (person.Id == ids[i])
                    {
                        people.RemoveAt(i);
                        people.Insert(i, person);

                        notSameId = false;
                        break;
                    }
                }

                if(notSameId)
                {
                    people.Add(person);
                    ids.Add(person.Id);
                }

                data = Console.ReadLine().Split();
            }

            //Order by Age
            people = people.OrderBy(age => age.Age).ToList();

            //Print people
            foreach(var person in people)
                Console.WriteLine($"{person.Name} with ID: {person.Id} is {person.Age} years old.");
        }
    }

    class Person
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public int Age { get; set; }
    }
}
