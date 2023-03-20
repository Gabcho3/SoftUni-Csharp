using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    internal class Car : Vehicle
    {
        private const double additionalFuelConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            :base(fuelQuantity, fuelConsumption + additionalFuelConsumption, tankCapacity) { }

    }
}
