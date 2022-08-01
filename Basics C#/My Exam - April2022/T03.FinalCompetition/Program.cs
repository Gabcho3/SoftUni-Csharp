using System;

namespace T03.FinalCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dancers = int.Parse(Console.ReadLine());
            double points = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string place = Console.ReadLine();
            
            double reward = points * dancers;
            switch(place)
            {
                case "Bulgaria": 
                    switch(season)
                    {
                        case "summer": reward -= reward * 0.05; 
                            break;
                        case "winter": reward -= reward * 0.08; 
                            break;
                    }
                    break;
                case "Abroad": reward += reward * 0.50;
                    switch (season)
                    {
                        case "summer": reward -= reward * 0.10; 
                            break;
                        case "winter": reward -= reward * 0.15; 
                            break;
                    }
                    break;
            }
            double forCharity = reward * 0.75;
            double forPerson = (reward * 0.25) / dancers;
            Console.WriteLine($"Charity - {forCharity:f2}");
            Console.WriteLine($"Money per dancer - {forPerson:f2}");
        }
    }
}
