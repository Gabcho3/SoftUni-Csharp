using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; } 

        public List<Child> Registry { get; set; }

        public int ChildrenCount => Registry.Count;

        public bool AddChild(Child child)
        {
            if (Registry.Count == Capacity)
                return false;

            Registry.Add(child);
            return true;
        }

        public bool RemoveChild(string childFullName)
        {
            var childToRemove = Registry.Find(x => x.FirstName + " " + x.LastName == childFullName);
            if (childToRemove == null)
                return false;

            Registry.Remove(childToRemove);
            return true;
        }

        public Child GetChild(string childFullName)
            => Registry.Find(x => x.FirstName + " " + x.LastName == childFullName);

        public string RegistryReport()
        {
            var output = new StringBuilder();
            output.Append($"Registered children in {Name}:");

            foreach(var child in Registry.OrderByDescending(x => x.Age).ThenBy(x => x.LastName).ThenBy(x => x.FirstName))
            {
                output.Append(Environment.NewLine + child.ToString());
            }
            return output.ToString();
        }
    }
}
