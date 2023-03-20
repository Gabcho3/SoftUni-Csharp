using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private static double coffeeMilliliters = 50;
        private static decimal coffeePrice = 3.50m;

        public Coffee(string name, double caffeine)
            :base(name, coffeePrice, coffeeMilliliters)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
