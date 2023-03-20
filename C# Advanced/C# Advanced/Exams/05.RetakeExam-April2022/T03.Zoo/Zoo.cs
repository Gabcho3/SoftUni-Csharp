using System.Collections.Generic;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        public List<Animal> Animals { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            string animalSpecies = animal.Species;
            string animalDiet = animal.Diet;

            if (animalSpecies == null || animalSpecies == string.Empty)
            {
                return "Invalid animal species.";
            }

            if (animalDiet != "herbivore" && animalDiet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (Animals.Count == Capacity)
            {
                return "The zoo is full.";
            }

            Animals.Add(animal);
            return $"Successfully added {animalSpecies} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            var animalsToRemove = Animals.FindAll(x => x.Species == species);
            Animals.RemoveAll(x => x.Species == species);
            return animalsToRemove.Count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
            => Animals.FindAll(x => x.Diet == diet);
        public Animal GetAnimalByWeight(double weight)
            => Animals.Find(x => x.Weight == weight);

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
            => $"There are {Animals.FindAll(x => x.Length >= minimumLength && x.Length <= maximumLength).Count} " +
            $"animals with a length between {minimumLength} and {maximumLength} meters.";
    }
}
