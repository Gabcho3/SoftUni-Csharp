using _01.Vehicles;
using System;
using System.Linq;

namespace _02.VehiclesExtension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Skip(1).ToArray();
            double[] truckData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Skip(1).ToArray();
            double[] busData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Skip(1).ToArray();

            Vehicle car = new Car(carData[0], carData[1], carData[2]);
            Vehicle truck = new Truck(truckData[0], truckData[1], truckData[2]);
            Bus bus = new Bus(busData[0], busData[1], busData[2]);

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmd = command[0];
                string typeVehicle = command[1];
                double value = double.Parse(command[2]);

                switch (cmd)
                {
                    case "Drive":
                        if (typeVehicle == "Car")
                            car.Drive(value);
                        else if (typeVehicle == "Truck")
                            truck.Drive(value);
                        else
                            bus.Drive(value);
                        break;

                    case "Refuel":
                        if (typeVehicle == "Car")
                            car.Refuel(value);
                        else
                            truck.Refuel(value);
                        break;

                    case "DriveEmpty":
                        bus.DriveEmpty(value);
                        break;
                }
            }
            Console.WriteLine(car.ToString() + Environment.NewLine + truck.ToString() + Environment.NewLine + bus.ToString());
        }
    }
}
