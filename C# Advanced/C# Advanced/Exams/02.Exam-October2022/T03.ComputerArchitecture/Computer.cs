using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private List<CPU> multiprocessor;

        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            multiprocessor = new List<CPU>();
        }

        public string Model { get; }

        public int Capacity { get; }

        public List<CPU> Multiprocessor => multiprocessor;

        public int Count => multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if(Capacity > Count)
            {
                multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            CPU toRemove = multiprocessor.FirstOrDefault(p => p.Brand == brand);
            return multiprocessor.Remove(toRemove);
        }

        public CPU MostPowerful()
        {
            return multiprocessor.OrderByDescending(p => p.Frequency).FirstOrDefault();
        }

        public CPU GetCPU(string brand)
        {
            return multiprocessor.FirstOrDefault(p => p.Brand == brand);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CPUs in the Computer {Model}:");
            foreach(var cpu in multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
