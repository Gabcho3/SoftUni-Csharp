using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Cryptography;

namespace T02._OldestFamMember
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int members = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < members; i++)
            {
                string[] nameAndAge = Console.ReadLine().Split();

                string name = nameAndAge[0];
                int age = int.Parse(nameAndAge[1]);

                Person person = new Person { Name = name, Age = age };

                people.Add(person);
            }

            Family family = new Family();

            family.AddMembers(people);

            Person oldestMember = family.GetOldestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }

    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    class Family
    {
        public List<Person> People { get; set; }

        public void AddMembers(List<Person> people)
        {
            People = people;
        }

        public Person GetOldestMember()
        {
            Person oldestMember = this.People.OrderByDescending(age => age.Age).First();

            return oldestMember;
        }
    }
}
