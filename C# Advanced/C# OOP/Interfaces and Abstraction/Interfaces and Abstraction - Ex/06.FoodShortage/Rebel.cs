using _04.BorderControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Food
{
    public class Rebel : IIdentifiable, IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; }

        public int Age { get; }

        private string Group { get; }

        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
