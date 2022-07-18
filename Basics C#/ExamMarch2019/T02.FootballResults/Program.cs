using System;

namespace T02.FootballResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string result1 = Console.ReadLine();
            string result2 = Console.ReadLine();
            string result3 = Console.ReadLine();

            int firstMatch1 = int.Parse(result1[0].ToString());
            int secondMatch1 = int.Parse(result2[0].ToString());
            int thirdMatch1 = int.Parse(result3[0].ToString());

            int firstMatch2 = int.Parse(result1[2].ToString());
            int secondMatch2 = int.Parse(result2[2].ToString());
            int thirdMatch2 = int.Parse(result3[2].ToString());

            int wins = 0;
            int draws = 0;
            int loses = 0;

            if (firstMatch1 > firstMatch2) wins++; 
            else if(firstMatch1 == firstMatch2) draws++; 
            else { loses++; }

            if (secondMatch1 > secondMatch2) wins++;
            else if (secondMatch1 == secondMatch2)  draws++; 
            else loses++; 

            if (thirdMatch1 > thirdMatch2) wins++; 
            else if (thirdMatch1 == thirdMatch2) draws++; 
            else loses++;
            
            Console.WriteLine($"Team won {wins} games.");
            Console.WriteLine($"Team lost {loses} games.");
            Console.WriteLine($"Drawn games: {draws}");
            
        }
    }
}
