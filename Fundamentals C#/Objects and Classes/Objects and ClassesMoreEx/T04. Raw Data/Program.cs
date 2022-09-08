using System;
using System.Collections.Generic;
using System.Linq;

namespace T04._Raw_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for(int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();

                string model = info[0];
                int engineSpeed = int.Parse(info[1]);
                int enginePower = int.Parse(info[2]);
                int cargoWeight = int.Parse(info[3]);
                string cargoType = info[4];

                var engine = new Engine { Speed = engineSpeed, Power = enginePower };

                var cargo = new Cargo { Weight = cargoWeight, Type = cargoType };

                var car = new Car(model, engine, cargo);

                cars.Add(car);
            }

            string input = Console.ReadLine();

            if(input == "fragile")
                cars = cars.Where(t => t.Cargo.Type == "fragile").Where(w => w.Cargo.Weight < 1000).ToList();

            else
                cars = cars.Where(t => t.Cargo.Type == "flamable").Where(p => p.Engine.Power > 250).ToList();

            foreach(var car in cars)
                Console.WriteLine(car.Model);
        }
    }

    class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }
    }

    class Engine
    {
        public int Speed { get; set; }

        public int Power { get; set; }
    }

    class Cargo
    {
        public int Weight { get; set; }

        public string Type { get; set; }
    }
}
