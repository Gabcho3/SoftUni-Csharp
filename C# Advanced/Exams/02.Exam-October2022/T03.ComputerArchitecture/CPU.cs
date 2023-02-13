using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        private string brand;
        private int cores;
        private double frequency;

        public CPU(string brand, int cores, double frequency)
        {
            Brand = brand;
            Cores = cores;
            Frequency = frequency;
        }

        public string Brand { get { return brand; } set { brand = value; } }

        public int Cores { get { return cores; } set { cores = value; } }

        public double Frequency { get { return frequency; } set { frequency = value; } }

        public override string ToString()
        {
            return $"{brand} CPU:\nCores: {cores}\nFrequency: {Frequency:f1} GHz";
        }
    }
}
