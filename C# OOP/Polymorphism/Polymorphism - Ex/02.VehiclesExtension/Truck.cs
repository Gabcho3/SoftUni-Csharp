using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    internal class Truck : Vehicle
    {
        private const double additionalFuelConsumption = 1.6;
        private const double tankFuelKeep = 0.95; //95% of tank

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            :base (fuelQuantity, fuelConsumption + additionalFuelConsumption, tankCapacity) { }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            if (FuelQuantity + liters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                return;
            }

            FuelQuantity += liters * tankFuelKeep;
        }
    }
}
