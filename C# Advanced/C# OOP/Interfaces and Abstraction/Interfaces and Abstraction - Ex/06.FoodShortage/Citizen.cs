using _06.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Citizen : IIdentifiable, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; }
        public int Age { get; }
        private string Id { get; }
        private string Birthdate { get; }

        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
