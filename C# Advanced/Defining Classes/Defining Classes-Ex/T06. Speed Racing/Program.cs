using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for(int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];
                double fuelAmount = double.Parse(data[1]);
                double fuelConsumptionFor1km = double.Parse(data[2]);

                Car car = new Car()
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumptionPerKilometer = fuelConsumptionFor1km
                };
                cars.Add(car);
            }

            string[] cmd;

            while(true)
            {
                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (cmd[0] == "End")
                    break;

                string model = cmd[1];
                double distanceTraveled = double.Parse(cmd[2]);

                Car car = cars.Where(x => x.Model == model).ToList()[0];
                car.CalculateIfCarCanMove(distanceTraveled);
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}