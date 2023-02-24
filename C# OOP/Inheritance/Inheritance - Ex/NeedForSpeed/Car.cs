using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsePowers, double fuel) : base(horsePowers, fuel)
        {
            this.DefaultFuelConsumption = 3;
        }
    }
}
