using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            string[] data;
            List<Trainers> trainers = new List<Trainers>();

            while (true)
            {
                data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "Tournament")
                    break;

                string trainerName = data[0];
                string pokemonName = data[1];
                string pokemonElement = data[2];
                int pokemonHealth = int.Parse(data[3]);

                Pokemon pokemon = new Pokemon() { Name = pokemonName, Element = pokemonElement, Health = pokemonHealth };

                if (!trainers.Any(x => x.Name == trainerName))
                {
                    Trainers trainer = new Trainers() { Name = trainerName, Badges = 0, Pokemons = new List<Pokemon>() { pokemon } };
                    trainers.Add(trainer);
                }

                else
                {
                    Trainers trainer = trainers.Find(x => x.Name == trainerName);

                    trainer.Pokemons.Add(pokemon);
                }
            }

            string element;

            while (true)
            {
                element = Console.ReadLine();

                if (element == "End")
                    break;

                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == element))
                    {
                        trainer.Badges++;
                    }

                    else
                    {
                        trainer.Pokemons.ForEach(x => x.Health -= 10);
                        trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, trainers.OrderByDescending(x => x.Badges)));
        }
    }
}