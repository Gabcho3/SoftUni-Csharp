using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Mammals.Felines
{
    internal abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; }

        public override string ToString()
            => $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
