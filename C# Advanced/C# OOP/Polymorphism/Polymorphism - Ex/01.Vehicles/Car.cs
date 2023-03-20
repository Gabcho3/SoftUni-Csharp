using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    internal class Car : Vehicle
    {
        private const double additionalFuelConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption)
            :base(fuelQuantity, fuelConsumption + additionalFuelConsumption) { }

        public override void Drive(double distance)
        {
            FuelQuantity -= distance * FuelConsumption;

            if(FuelQuantity <= 0)
            {
                FuelQuantity += distance * FuelConsumption;
                Console.WriteLine("Car needs refueling");
            }

            else
            {
                Console.WriteLine($"Car travelled {distance} km");
            }
        }

        public override void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
    }
}
