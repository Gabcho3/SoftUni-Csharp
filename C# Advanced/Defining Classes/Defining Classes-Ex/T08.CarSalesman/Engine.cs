﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Engine
    {
        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; } //optional

        public string Efficiency { get; set; } //optional
    }
}
