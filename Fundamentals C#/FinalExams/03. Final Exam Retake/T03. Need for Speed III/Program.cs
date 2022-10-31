using System;
using System.Collections.Generic;
using System.Net.Http;

namespace T03._Need_for_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var cars = new Dictionary<string, Car>(); //Name, Mileage && Fuel

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split('|');

                Car car = new Car()
                {
                    Mileage = int.Parse(data[1]),
                    Fuel = int.Parse(data[2])
                };

                cars[data[0]] = car;
            }

            string[] command = Console.ReadLine().Split(" : ");

            while (command[0] != "Stop")
            {
                string car = command[1];

                switch (command[0])
                {
                    case "Drive":
                        int distance = int.Parse(command[2]);
                        int fuel = int.Parse(command[3]);
                        Drive(cars, car, distance, fuel);
                        break;

                    case "Refuel":
                        fuel = int.Parse(command[2]);
                        Refuel(cars, car, fuel);
                        break;

                    case "Revert":
                        int kms = int.Parse(command[2]);
                        Revert(cars, car, kms);
                        break;
                }


                command = Console.ReadLine().Split(" : ");
            }

            foreach (var car in cars)
                Console.WriteLine(
                    $"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
        }

        static void Drive(Dictionary<string, Car> cars, string car, int distance, int fuel)
        {
            if (cars[car].Fuel - fuel < 0)
                Console.WriteLine("Not enough fuel to make that ride");

            else
            {
                cars[car].Mileage += distance;
                cars[car].Fuel -= fuel;
                Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                if (cars[car].Mileage >= 100_000)
                {
                    Console.WriteLine($"Time to sell the {car}!");
                    cars.Remove(car);
                }
            }
        }

        static void Refuel(Dictionary<string, Car> cars, string car, int fuel)
        {
            int refueled = 0;
            while (cars[car].Fuel < 75 && fuel > 0)
            {
                cars[car].Fuel++;
                fuel--;
                refueled++;
            }

            Console.WriteLine($"{car} refueled with {refueled} liters");
        }

        static void Revert(Dictionary<string, Car> cars, string car, int kms)
        {
            cars[car].Mileage -= kms;

            if (cars[car].Mileage < 10_000)
                cars[car].Mileage = 10_000;

            else
                Console.WriteLine($"{car} mileage decreased by {kms} kilometers");
        }
    }

    class Car
    {
        public int Mileage { get; set; }

        public int Fuel { get; set; }
    }
}

