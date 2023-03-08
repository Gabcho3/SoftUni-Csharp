using _01.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.VehiclesExtension
{
    internal class Bus : Vehicle
    {
        private const double additionalFuelConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            :base(fuelQuantity, fuelConsumption + additionalFuelConsumption, tankCapacity) { }

        public void DriveEmpty(double distance)
        {
            FuelQuantity -= distance * (FuelConsumption - additionalFuelConsumption);

            if (FuelQuantity <= 0)
            {
                FuelQuantity += distance * (FuelConsumption - additionalFuelConsumption);
                Console.WriteLine("Bus needs refueling");
            }

            else
            {
                Console.WriteLine($"Bus travelled {distance} km");
            }
        }
    }
}
