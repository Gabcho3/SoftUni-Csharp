using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity) 
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model { get;set; }

        public int Capacity { get; set; }

        public List<CPU> Multiprocessor { get; set; }

        public int Count => Multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if (Multiprocessor.Count < Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            bool exist = Multiprocessor.Any(x => x.Brand == brand);
            Multiprocessor.RemoveAll(x => x.Brand == brand);
            return exist;
        }

        public CPU MostPowerful() => Multiprocessor.OrderByDescending(x => x.Frequency).First();

        public CPU GetCPU(string brand) => Multiprocessor.Find(x => x.Brand == brand);

        public string Report()
        {
            StringBuilder output = new StringBuilder();
            output.Append($"CPUs in the Computer {Model}:");
            foreach (var cpu in Multiprocessor)
            {
                output.Append(Environment.NewLine + cpu.ToString());
            }

            return output.ToString();
        }
    }
}
