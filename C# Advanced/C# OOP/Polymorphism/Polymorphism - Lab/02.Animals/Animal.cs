using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        public Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }

        public string Name { get; }
        public string FavouriteFood { get; }

        public virtual string ExplainSelf()
        {
            return null;
        }
    }
}
