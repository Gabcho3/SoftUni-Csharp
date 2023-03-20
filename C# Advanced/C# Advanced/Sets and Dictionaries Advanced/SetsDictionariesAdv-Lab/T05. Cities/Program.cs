using System;
using System.Collections.Generic;

namespace T05._Cities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cities = int.Parse(Console.ReadLine());
            var citiesInfo = new Dictionary<string, Dictionary<string, List<string>>>(); //continent, [country, city]
            for(int i = 0; i < cities; i++)
            {
                string[] data = Console.ReadLine().Split();
                string continent = data[0];
                string country = data[1];
                string city = data[2];

                if (citiesInfo.ContainsKey(continent))
                {
                    if (citiesInfo[continent].ContainsKey(country))
                    {
                        citiesInfo[continent][country].Add(city);
                    }
                    
                    else
                    {
                        citiesInfo[continent][country] = new List<string> { city };
                    }
                }

                else
                {
                    citiesInfo.Add(continent, new Dictionary<string, List<string>>());
                    citiesInfo[continent].Add(country, new List<string>() { city });
                }
            }

            foreach(var (continent, countries) in citiesInfo)
            {
                Console.WriteLine(continent + ":");
                foreach(var country in countries)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
