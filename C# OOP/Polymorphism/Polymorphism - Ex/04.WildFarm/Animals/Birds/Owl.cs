using _04.WildFarm.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Birds
{
    internal class Owl : Bird
    {
        private const double weightPerPiece = 0.25;

        public Owl(string name, double weight, double wingSize)
            :base(name, weight, wingSize) { }

        public override string ProduceSound()
            => "Hoot Hoot";

        public override void Eat(F food)
        {
            if (food.GetType().Name != "Meat")
                Console.WriteLine($"{GetType().Name} does not eat {food.Quantity}");

            else
            {
                Weight += food.Quantity * weightPerPiece;
                FoodEaten += food.Quantity;
            }
        }
    }
}
