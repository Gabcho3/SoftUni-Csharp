using System;

namespace T01._Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            string[] phrases = new string[]
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            string[] events = new string[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            string[] authors = new string[]
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };

            string[] cities = new string[]
            {
                "Burgas", 
                "Sofia", 
                "Plovdiv", 
                "Varna", 
                "Ruse"
            };


            Random random = new Random();

            for(int i = 0; i < lines; i++)
            {
                int randomIndex = random.Next(phrases.Length); //for phrases
                int randomIndex2 = random.Next(events.Length); //for events
                int randomIndex3 = random.Next(authors.Length); //for authors
                int randomIndex4 = random.Next(cities.Length); //for cities

                Console.WriteLine("{0} {1} {2} - {3}.", phrases[randomIndex], events[randomIndex2], authors[randomIndex3], cities[randomIndex4]);
            }
        }
    }
}
