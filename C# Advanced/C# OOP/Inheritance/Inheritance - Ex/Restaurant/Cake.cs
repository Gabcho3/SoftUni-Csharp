using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private static double grams = 250;
        private static double calories = 1000;
        private static decimal price = 5;

        public Cake(string name)
            :base(name, price, grams, calories) { }
    }
}
