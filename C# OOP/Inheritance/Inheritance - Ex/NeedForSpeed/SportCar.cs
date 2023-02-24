using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePowers, double fuel) : base(horsePowers, fuel)
        {
            this.DefaultFuelConsumption = 10;
        }
    }
}
