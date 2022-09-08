using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Speed_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Car car = new Car();
            List<Car> cars = new List<Car>();


            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();

                car = new Car
                {
                    Model = info[0],
                    FuelAmount = double.Parse(info[1]),
                    FuelPerKm = double.Parse(info[2]),
                    TraveledDistance = 0
                };

                cars.Add(car);
            }

            string[] command = Console.ReadLine().Split().Where(w => w != "Drive").ToArray();

            while (command[0] != "End")
            {
                string carModel = command[0];
                double km = double.Parse(command[1]);
                int indexOfCar = 0;

                for(int i = 0; i < cars.Count; i++)
                {
                    if (cars[i].Model == carModel)
                        indexOfCar = i;
                }

                car.CalculateDistance(cars, km, indexOfCar);

                command = Console.ReadLine().Split().Where(w => w != "Drive").ToArray();
            }

            foreach (var vehicle in cars)
                Console.WriteLine($"{vehicle.Model} {vehicle.FuelAmount:f2} {vehicle.TraveledDistance}");
        }
    }

    class Car
    {
        public string  Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelPerKm { get; set; }

        public double TraveledDistance { get; set; }

        public void CalculateDistance(List<Car> cars, double km, int indexOfCar)
        {
            if (km * cars[indexOfCar].FuelPerKm <= cars[indexOfCar].FuelAmount)
            {
                cars[indexOfCar].FuelAmount -= km * cars[indexOfCar].FuelPerKm;
                cars[indexOfCar].TraveledDistance += km;
            }

            else
                Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}
