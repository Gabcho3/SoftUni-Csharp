using _04.WildFarm.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Mammals
{
    internal class Mouse : Mammal
    {
        private const double weightPerPiece = 0.10;

        public Mouse(string name, double weight, string livingRegion)
            :base(name, weight, livingRegion) { }

        public override string ProduceSound()
            => "Squeak";

        public override void Eat(F food)
        {
            if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Fruit")
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
                return;
            }

            Weight += food.Quantity * weightPerPiece;
            FoodEaten += food.Quantity;
        }
    }
}
