using System;

namespace T05.MovieRatings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int films = int.Parse(Console.ReadLine());
            double maxRating = double.MinValue;
            double minRating = double.MaxValue;
            string bestFilm = "";
            string worstFilm = "";
            double total = 0;
            for(int film  = 1; film <= films; film++)
            {
                string name = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());
                if (rating > maxRating)
                {
                    maxRating = rating; ; 
                    bestFilm = name;
                }
                if (rating < minRating)
                {
                    minRating = rating;
                    worstFilm = name;
                }
                total += rating;
            }
            Console.WriteLine($"{bestFilm} is with highest rating: {maxRating:f1}");
            Console.WriteLine($"{worstFilm} is with lowest rating: {minRating:f1}");
            double average = total / films;
            Console.WriteLine($"Average rating: {average:f1}");
        }
    }
}
