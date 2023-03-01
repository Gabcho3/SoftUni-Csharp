using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        //Fields
        private string name;
        private Dough dough;

        //Constructor
        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            Toppings = new List<Topping>();
        }

        //Properties
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        private Dough Dough { get { return dough; } set { dough = value; } }

        private List<Topping> Toppings { get; set; }

        public double TotalCalories
        {
            get
            {
                double totalCalories = Dough.GetCalories();
                foreach (var topping in Toppings)
                {
                    totalCalories += topping.GetCalories();
                }
                return totalCalories;
            }
        }

        //Methods
        public void AddTopping(Topping topping)
        {
            if (Toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            Toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:f2} Calories.";
        }
    }
}
