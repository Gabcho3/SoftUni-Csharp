using System;
using System.Linq;

namespace _01.Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Skip(1).ToArray();
            double[] truckData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Skip(1).ToArray();

            Vehicle car = new Car(carData[0], carData[1]);
            Vehicle truck = new Truck(truckData[0], truckData[1]);

            int lines = int.Parse(Console.ReadLine());

            for(int i = 0; i < lines; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmd = command[0];
                string typeVehicle = command[1];
                double value = double.Parse(command[2]);

                switch(cmd)
                {
                    case "Drive":
                        if (typeVehicle == "Car")
                            car.Drive(value);
                        else
                            truck.Drive(value);
                        break;

                    case "Refuel":
                        if (typeVehicle == "Car")
                            car.Refuel(value);
                        else
                            truck.Refuel(value);
                        break;
                }
            }
            Console.WriteLine(car.ToString() + Environment.NewLine + truck.ToString());
        }
    }
}
