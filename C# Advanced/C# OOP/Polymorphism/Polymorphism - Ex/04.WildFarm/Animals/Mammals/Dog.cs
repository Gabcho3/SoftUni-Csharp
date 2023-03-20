using _04.WildFarm.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Mammals
{
    internal class Dog : Mammal
    {
        private const double weightPerPiece = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion) { }

        public override string ProduceSound()
            => "Woof!";

        public override void Eat(F food)
        {
            if (food.GetType().Name != "Meet")
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
                return;
            }

            Weight += food.Quantity * weightPerPiece;
            FoodEaten += food.Quantity;
        }
    }
}
