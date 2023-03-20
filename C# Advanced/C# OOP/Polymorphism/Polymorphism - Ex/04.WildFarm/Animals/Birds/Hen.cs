using _04.WildFarm.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Birds
{
    internal class Hen : Bird
    {
        private const double weightPerPiece = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize) { }

        public override string ProduceSound()
            => "Cluck";

        public override void Eat(F food)
        {
            Weight += food.Quantity * weightPerPiece;
            FoodEaten += food.Quantity;
        }
    }
}
