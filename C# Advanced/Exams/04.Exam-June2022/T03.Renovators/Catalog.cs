using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRemovetors, string project)
        {
            Name = name;
            NeededRenovators = neededRemovetors;
            Project = project;
            Renovators = new List<Renovator>();
        }

        public string Name { get; set; }

        public int NeededRenovators { get; set; }

        public string Project { get; set; }

        public List<Renovator> Renovators { get; set; }

        public int Count => Renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            string renovatorName = renovator.Name;
            string renovatorSpeciality = renovator.Type;

            if (renovatorName == null || renovatorName == string.Empty || renovatorSpeciality == null || renovatorSpeciality == string.Empty)
            {
                return "Invalid renovator's information.";
            }

            if (NeededRenovators == 0)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            Renovators.Add(renovator);
            NeededRenovators--;
            return $"Successfully added {renovatorName} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            var renovator = Renovators.Find(x => x.Name == name);

            if (renovator == null)
                return false;

            Renovators.Remove(renovator);
            NeededRenovators++;
            return true;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            var renovatorsToRemove = Renovators.FindAll(x => x.Type == type);
            Renovators.RemoveAll(x => x.Type == type);
            NeededRenovators += renovatorsToRemove.Count;
            return renovatorsToRemove.Count;
        }

        public Renovator HireRenovator(string name)
        {
            var renovatorToHire = Renovators.Find(x => x.Name == name);
            
            if(renovatorToHire != null)
            {
                renovatorToHire.Hired = true;
            }
            return renovatorToHire;
        }

        public List<Renovator> PayRenovators(int days) => Renovators.Where(x => x.Days >= days).ToList();

        public string Report()
        {
            string output = $"Renovators available for Project {Project}:";
            foreach (var renovator in Renovators.Where(x => !x.Hired))
            {
                output += Environment.NewLine + renovator.ToString();
            }
            return output;
        }
    }
}
