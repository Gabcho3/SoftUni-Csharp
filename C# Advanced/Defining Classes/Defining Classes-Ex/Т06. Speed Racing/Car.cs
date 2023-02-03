using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }


        public double DistanceTraveled { get; set; }

        public void CalculateIfCarCanMove(double distanceTraveled)
        {
            if (FuelConsumptionPerKilometer * distanceTraveled <= FuelAmount)
            {
                DistanceTraveled += distanceTraveled;
                FuelAmount -= FuelConsumptionPerKilometer * distanceTraveled;
            }

            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {DistanceTraveled}";
        }
    }
}
