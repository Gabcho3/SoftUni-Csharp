using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; }
        public string Color { get; }

        public string Start()
            => "Engine Start";

        public string Stop()
            => "Breaaak!";

        public override string ToString()
            => $"{Color} Seat {Model}";
    }
}
