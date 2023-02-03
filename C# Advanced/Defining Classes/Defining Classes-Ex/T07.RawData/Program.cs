namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                string model = data[0];

                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);
                Engine engine = new Engine() { Speed = engineSpeed, Power = enginePower };

                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];
                Cargo cargo = new Cargo() { Weight = cargoWeight, Type = cargoType };

                double tire1Pressure = double.Parse(data[5]);
                int tire1Age = int.Parse(data[6]);
                double tire2Pressure = double.Parse(data[7]);
                int tire2Age = int.Parse(data[8]);
                double tire3Pressure = double.Parse(data[9]);
                int tire3Age = int.Parse(data[10]);
                double tire4Pressure = double.Parse(data[11]);
                int tire4Age = int.Parse(data[12]);

                Tire[] tires = new Tire[4]
                {
                    new Tire() {Pressure = tire1Pressure, Age = tire1Age},
                    new Tire() {Pressure = tire2Pressure, Age = tire2Age},
                    new Tire() {Pressure = tire3Pressure, Age = tire3Age},
                    new Tire() {Pressure = tire4Pressure, Age = tire4Age},

                };

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string cmd = Console.ReadLine();

            if (cmd == "fragile")
            {
                cars = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(x => x.Pressure < 1)).ToList();
            }

            else
            {
                cars = cars.Where(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250).ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }
    }
}