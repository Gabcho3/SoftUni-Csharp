namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> listOfTires = new List<Tire[]>();
            List<Engine> listOfEngines = new List<Engine>();
            List<Car> cars = new List<Car>();
            string[] cmd;
            while(true)
            {
                cmd = Console.ReadLine().Split();

                if (cmd[0] == "No")
                {
                    break;
                }

                Tire[] tires = new Tire[4]
                {
                    new Tire(int.Parse(cmd[0]), double.Parse(cmd[1])),
                    new Tire(int.Parse(cmd[2]), double.Parse(cmd[3])),
                    new Tire(int.Parse(cmd[4]), double.Parse(cmd[5])),
                    new Tire(int.Parse(cmd[6]), double.Parse(cmd[7]))
                };

                listOfTires.Add(tires);
            }

            while(true)
            {
                cmd = Console.ReadLine().Split();

                if (cmd[0] == "Engines")
                {
                    break;
                }

                int horsePower = int.Parse(cmd[0]);
                double cubicCapacity = double.Parse(cmd[1]);

                listOfEngines.Add(new Engine(horsePower, cubicCapacity));
            }

            while(true)
            {
                cmd = Console.ReadLine().Split();

                if (cmd[0] == "Show")
                {
                    Func<Car, bool> findSpecial = car =>
                    {
                        double sum = 0;

                        foreach(var tire in car.Tires)
                        {
                            sum += tire.Pressure;
                        }

                        return car.Year >= 2017 && car.Engine.HorsePower > 330 && sum >= 9 && sum <= 10;
                    };

                    cars = cars.Where(x => findSpecial(x)).ToList();

                    foreach (var vehicle in cars)
                    {
                        Console.WriteLine(vehicle.WhoAmI());
                    }

                    return;
                }

                string make = cmd[0];
                string model = cmd[1];
                int year = int.Parse(cmd[2]);

                int fuelQuantity = int.Parse(cmd[3]);
                int fuelConsumption = int.Parse(cmd[4]);

                int engineIndex = int.Parse(cmd[5]);
                int tiresEngine = int.Parse(cmd[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, listOfEngines[engineIndex], listOfTires[tiresEngine]);
                car.Drive(20);

                cars.Add(car);
            }
        }
    }
}