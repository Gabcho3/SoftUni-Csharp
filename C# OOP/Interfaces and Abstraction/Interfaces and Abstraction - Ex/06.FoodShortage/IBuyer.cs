using _04.BorderControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Food
{
    public interface IBuyer : IIdentifiable
    {
        int Food { get; set; }

        void BuyFood();
    }
}
