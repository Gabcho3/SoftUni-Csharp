using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    internal class Truck : Vehicle
    {
        private const double additionalFuelConsumption = 1.6;
        private const double tankFuelKeep = 0.95; //95% of tank

        public Truck(double fuelQuantity, double fuelConsumption)
            :base (fuelQuantity, fuelConsumption + additionalFuelConsumption) { }

        public override void Drive(double distance)
        {
            FuelQuantity -= distance * FuelConsumption;

            if (FuelQuantity <= 0)
            {
                FuelQuantity += distance * FuelConsumption;
                Console.WriteLine("Truck needs refueling");
            }

            else
            {
                Console.WriteLine($"Truck travelled {distance} km");
            }
        }

        public override void Refuel(double liters)
        {
            FuelQuantity += liters * tankFuelKeep;
        }
    }
}
