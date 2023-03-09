using _04.WildFarm.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Mammals.Felines
{
    internal class Cat : Feline
    {
        private double weightPerPiece = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed)
            :base(name, weight, livingRegion, breed) { }

        public override string ProduceSound()
            => "Meow";

        public override void Eat(F food)
        {
            if(food.GetType().Name != "Vegetable" &&  food.GetType().Name != "Meat")
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
                return;
            }

            Weight += food.Quantity * weightPerPiece;
            FoodEaten += food.Quantity;
        }
    }
}
