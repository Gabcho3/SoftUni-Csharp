using System;
using System.Diagnostics.Contracts;

namespace _04.PizzaCalories
{
    public class Dough
    {
        //Modifiers fields
        private const double whiteModifier = 1.5;
        private const double wholegrainModifier = 1.0;
        private const double crispyModifier = 0.9;
        private const double chewyModifier = 1.1;
        private const double homemadeModifier = 1.0;

        //Fields
        private string flourType;
        private string bakingTechique;
        private double grams;

        //Constructor
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = weight;
        }

        //Properties
        private string FlourType
        {
            get { return flourType; }
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }

        private string BakingTechnique
        {
            get { return bakingTechique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechique = value;
            }
        }

        private double Grams
        {
            get { return grams; }
            set
            {
                if (value < 1 && value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                grams = value;
            }
        }

        public double CaloriesPerGram
        {
            get
            {
                double doughCaloriesPerGram = 2;

                switch(flourType.ToLower())
                {
                    case "white": doughCaloriesPerGram *= whiteModifier; break;
                    case "wholegrain": doughCaloriesPerGram *= wholegrainModifier; break;
                }

                switch(bakingTechique.ToLower())
                {
                    case "crispy": doughCaloriesPerGram *= crispyModifier; break;
                    case "chewy": doughCaloriesPerGram *= chewyModifier; break;
                    case "homemade": doughCaloriesPerGram *= homemadeModifier; break;
                }

                return doughCaloriesPerGram;
            }
        }

        //Methods
        public double GetCalories()
            => grams * CaloriesPerGram;
    }
}