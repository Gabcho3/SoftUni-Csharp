using Cars;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public string Model { get; }
        public string Color { get; }
        public int Battery { get; }

        public string Start()
            => "Engine Start";

        public string Stop()
            => "Breaaak!";

        public override string ToString()
            => $"{Color} Tesla {Model} with {Battery} Batteries";
    }
}
