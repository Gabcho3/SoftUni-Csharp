using System;

namespace _04.PizzaCalories
{
    public class Topping
    {
        //Modifiers field
        private const double meatModifier = 1.2;
        private const double veggiesModifier = 0.8;
        private const double cheeseModifier = 1.1;
        private const double sauceModifier = 0.9;

        //Fields
        private string type;
        private double grams;

        //Constructor
        public Topping(string type, double grams)
        {
            Type = type;
            Grams = grams;
        }

        //Properties
        private string Type
        {
            get { return type; }
            set
            {
                if(value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }

        private double Grams
        {
            get { return grams; }
            set
            {
                if(value < 1 || value > 50)
                {
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                }
                grams = value;
            }
        }

        private double CaloriesPerGram
        {
            get
            {
                double toppingCaloriesPerGram = 2;

                switch(type.ToLower())
                {
                    case "meat": toppingCaloriesPerGram *= meatModifier; break;
                    case "veggies": toppingCaloriesPerGram *= veggiesModifier; break;
                    case "cheese": toppingCaloriesPerGram *= cheeseModifier; break;
                    case "sauce": toppingCaloriesPerGram *= sauceModifier; break;
                }
                return toppingCaloriesPerGram;
            }
        }

        //Methods
        public double GetCalories()
            => grams * CaloriesPerGram;
    }
}