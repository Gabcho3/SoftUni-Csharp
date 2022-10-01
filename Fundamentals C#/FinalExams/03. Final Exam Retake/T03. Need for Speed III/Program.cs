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

            List<Car> cars = new List<Car>();

            for(int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split('|');

                Car car = new Car() 
                { 
                    Name = data[0], 
                    Distance = int.Parse(data[1]),
                    Fuel = int.Parse(data[2]) 
                };

                cars.Add(car);
            }

            string[] command = Console.ReadLine().Split(" : ");

            while (command[0] != "Stop")
            {
                string car = command[1];

                switch (command[0])
                {
                    case "Drive":
                        cars = Drive(cars, command, car);
                        break;

                    case "Refuel":
                        cars = Refuel(cars, command, car);
                        break;

                    case "Revert":
                        cars = Revert(cars, command, car);
                        break;
                }

                command = Console.ReadLine().Split(" : ");
            }

            foreach (var car in cars)
                Console.WriteLine($"{car.Name} -> Mileage: {car.Distance} kms, Fuel in the tank: {car.Fuel} lt.");
        }

        static List<Car> Drive (List<Car> cars, string[] command, string car)
        {
            int distance = int.Parse(command[2]);
            int fuel = int.Parse(command[3]);

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].Name == car)
                {
                    if (cars[i].Fuel < fuel)
                        Console.WriteLine("Not enough fuel to make that ride");

                    else
                    {
                        cars[i].Distance += distance;
                        cars[i].Fuel -= fuel;

                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }

                    if (cars[i].Distance > 100_000)
                    {
                        Console.WriteLine($"Time to sell the {car}!");
                        cars.RemoveAt(i);
                    }
                }

            }

            return cars;
        }

        static List<Car> Refuel(List<Car> cars, string[] command, string car)
        {
            int fuel = int.Parse(command[2]);
            int refuel = 0;

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].Name == car)
                {
                    while (cars[i].Fuel < 75 && refuel <= fuel)
                    {
                        cars[i].Fuel++;
                        refuel++;
                    }

                    Console.WriteLine($"{car} refueled with {refuel} liters");
                }
            }

            return cars;
        }

        static List<Car> Revert(List<Car> cars, string[] command, string car)
        {
            int km = int.Parse(command[2]);

            for (int i = 0; i < cars.Count; i++)
            {
                if (cars[i].Name == car)
                {
                    cars[i].Distance -= km;

                    if (cars[i].Distance >= 10_000)
                        Console.WriteLine($"{car} mileage decreased by {km} kilometers");

                    else
                        cars[i].Distance = 10_000;
                }
            }

            return cars;
        }
    }

    class Car
    {
        public string Name { get; set; }

        public int Distance { get; set; }

        public int Fuel { get; set; }
    }
}
