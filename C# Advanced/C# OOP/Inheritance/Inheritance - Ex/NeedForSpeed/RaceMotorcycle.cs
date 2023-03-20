using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePowers, double fuel) : base(horsePowers, fuel)
        {
            this.DefaultFuelConsumption = 8;
        }
    }
}
