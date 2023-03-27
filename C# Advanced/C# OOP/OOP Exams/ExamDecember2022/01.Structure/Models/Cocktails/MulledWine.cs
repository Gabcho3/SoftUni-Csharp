using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class MulledWine : Cocktail
    {
        private const double price = 13.50;

        public MulledWine(string name, string size)
            : base(name, size, price) { }
    }
}
