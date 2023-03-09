using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Food
{
    internal abstract class F
    {
        public F(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; }
    }
}
