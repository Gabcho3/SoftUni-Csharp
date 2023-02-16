using System;
using System.Collections.Generic;
using System.Linq;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fishes = new List<Fish>();
        }

        public List<Fish> Fishes { get; set; }

        public string Material { get; set; }

        public int Capacity { get; set; }

        public int Count => Fishes.Count;

        public string AddFish(Fish fish)
        {
            string fishType = fish.FishType;
            double fishLength = fish.Length;
            double fishWeight = fish.Weight;

            if (fishType == null || fishType == string.Empty || fishLength <= 0 || fishWeight <= 0)
            {
                return "Invalid fish.";
            }

            if (Fishes.Count == Capacity)
            {
                return "Fishing net is full.";
            }
            Fishes.Add(fish);
            return $"Successfully added {fishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            var fishToRemove = Fishes.Find(x => x.Weight == weight);
            Fishes.Remove(fishToRemove);
            return fishToRemove != null ;
        }

        public Fish GetFish(string fishType)
            => Fishes.Find(x => x.FishType == fishType);

        public Fish GetBiggestFish()
            => Fishes.OrderByDescending(x => x.Length).First();

        public string Report()
        {
            string output = $"Into the {Material}:";

            foreach (var fish in Fishes.OrderByDescending(x => x.Length))
            {
                output += Environment.NewLine + fish.ToString();
            }
            return output;
        }
    }
}
