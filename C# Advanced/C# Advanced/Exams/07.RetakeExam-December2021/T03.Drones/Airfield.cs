using System;
using System.Collections.Generic;
using System.Linq;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        public List<Drone> Drones { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double LandingStrip { get; set; }

        public int Count => Drones.Count;

        public string AddDrone(Drone drone)
        {
            string droneName = drone.Name;
            string droneBrand = drone.Brand;
            int droneRange = drone.Range;

            if (droneName == null || droneName == string.Empty
                || droneBrand == null || droneBrand == string.Empty
                || droneRange < 5 || droneRange > 15)
            {
                return "Invalid drone.";
            }

            if (Drones.Count == Capacity)
            {
                return "Airfield is full.";
            }
            Drones.Add(drone);
            return $"Successfully added {droneName} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            var droneToRemove = Drones.Find(x => x.Name == name);

            if (droneToRemove == null)
                return false;

            Drones.Remove(droneToRemove);
            return true;
        }

        public int RemoveDroneByBrand(string brand)
        {
            var dronesToRemove = Drones.FindAll(x => x.Brand == brand);
            Drones.RemoveAll(x => x.Brand == brand);
            return dronesToRemove.Count;
        }

        public Drone FlyDrone(string name)
        {
            var droneToFly = Drones.Find(x => x.Name == name);

            if (droneToFly != null)
            {
                droneToFly.Available = false;
            }
            return droneToFly;
        }

        public List<Drone> FlyDronesByRange(int range)
        { 
            var dronesToFly = Drones.Where(x => x.Range >= range).ToList();
            for(int i = 0; i < dronesToFly.Count; i++)
            {
                dronesToFly[i] = FlyDrone(dronesToFly[i].Name);
            }
            return dronesToFly;
        }

        public string Report()
        {
            string output = $"Drones available at {Name}:";
            foreach(var drone in Drones.Where(x => x.Available == true))
            {
                output += Environment.NewLine + drone.ToString();
            }
            return output;
        }
    }
}
