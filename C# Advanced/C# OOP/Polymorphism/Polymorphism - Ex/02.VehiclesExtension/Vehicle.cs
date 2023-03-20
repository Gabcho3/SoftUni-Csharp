using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    internal abstract class Vehicle
    {
        private double tankCapacity;
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public double TankCapacity
        {
            get { return tankCapacity; }
            set
            {
                if (FuelQuantity > value)
                {
                    FuelQuantity = 0;
                }
                tankCapacity = value;
            }
        }

        public virtual void Drive(double distance)
        {
            FuelQuantity -= distance * FuelConsumption;

            string vehicleType = this.GetType().Name;

            if (FuelQuantity <= 0)
            {
                FuelQuantity += distance * FuelConsumption;
                Console.WriteLine($"{vehicleType} needs refueling");
            }

            else
            {
                Console.WriteLine($"{vehicleType} travelled {distance} km");
            }
        }

        public virtual void Refuel(double liters)
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

            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name:f2}: {this.FuelQuantity:f2}";
        }
    }
}
