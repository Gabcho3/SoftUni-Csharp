using System;

namespace T06.FavoriteMovie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ASCII: A - Z -> 65 - 90
            //ASCII: a - z -> 97 - 122
            string film = Console.ReadLine();

            int filmCount = 0;
            int sum = 0;
            int maxSum = int.MinValue;
            string bestFilm = null;

            while (film != "STOP")
            {
                int length = film.Length;
                for (int i = 0; i < length; i++)
                {
                    char letter = film[i];
                    sum += letter;
                    if (letter >= 65 && letter <= 90)
                        sum -= length;
                    if (letter >= 97 && letter <= 122)
                        sum -= length * 2;
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                    bestFilm = film;
                }

                filmCount++;
                if (filmCount == 7)
                {
                    Console.WriteLine("The limit is reached.");
                    break;
                }

                sum = 0;
                film = Console.ReadLine();
            }
            Console.WriteLine("The best movie for you is {0} with {1} ASCII sum.", bestFilm, maxSum);
        }
    }
}
