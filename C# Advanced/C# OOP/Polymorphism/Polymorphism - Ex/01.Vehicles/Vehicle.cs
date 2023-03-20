using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    internal abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public abstract void Drive(double distance);
        public abstract void Refuel(double liters);

        public override string ToString()
        {
            return $"{this.GetType().Name:f2}: {this.FuelQuantity:f2}";
        }
    }
}
