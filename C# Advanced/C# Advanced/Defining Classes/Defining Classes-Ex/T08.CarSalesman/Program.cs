using System.Drawing;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];
                int power = int.Parse(data[1]);

                Engine engine = new Engine()
                {
                    Model = model,
                    Power = power
                };


                if (data.Length >= 3)
                {
                    if (int.TryParse(data[2], out int diplacement))
                    {
                        engine.Displacement = diplacement;
                    }

                    else
                    {
                        engine.Efficiency = data[2];
                    }
                }

                if (data.Length == 4)
                {
                    engine.Efficiency = data[3];
                }

                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = data[0];
                string engineModel = data[1];
                Engine engine = engines.Where(x => x.Model == engineModel).ToList()[0];

                Car car = new Car()
                {
                    Model = model,
                    Engine = engine,
                };


                if (data.Length >= 3)
                {
                    if (int.TryParse(data[2], out int weight))
                    {
                        car.Weight = weight;
                    }

                    else
                    {
                        car.Color = data[2];
                    }
                }

                if (data.Length == 4)
                {
                    car.Color = data[3];
                }
                
                cars.Add(car);
            }

            Console.WriteLine(string.Join("", cars));
        }
    }
}