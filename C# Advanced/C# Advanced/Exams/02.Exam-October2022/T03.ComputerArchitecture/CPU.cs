using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        public CPU(string brand, int cores, double frequency)
        {
            Brand = brand;
            Cores = cores;
            Frequency = frequency;
        }

        public string Brand { get; }

        public int Cores { get; }

        public double Frequency { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Brand} CPU:");
            sb.AppendLine($"Cores: {Cores}");
            sb.AppendLine($"Frequency: {Frequency:f1} GHz");

            return sb.ToString().TrimEnd();
        }
    }
}
