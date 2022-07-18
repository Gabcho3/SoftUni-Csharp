using System;

namespace T06.WeddingSeats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string lastSector = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int placesInOddSector = int.Parse(Console.ReadLine());

            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string sectors = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int index;
            bool markLastLetter = false;
            int counterPlaces = 0;

            for (int i = 0; i < sectors.Length; i++, rows++)
            {
                string sector = sectors[i].ToString();
                if(sector == lastSector && !markLastLetter)
                {   
                    if(sector == "Z")
                    {
                        lastSector = sectors;
                    }
                    else
                    {
                        lastSector = sectors[i+1].ToString();
                        markLastLetter = true;
                    }
                }
                while (sector != lastSector)
                {
                    for (int row = 1; row <= rows; row++)
                    {
                        string place;
                        if (row % 2 != 0)
                        {
                            for (index = 0; index < placesInOddSector; index++, counterPlaces++)
                            {
                                place = alphabet[index].ToString();
                                Console.WriteLine($"{sector}{row}{place}");
                            }
                            continue;
                        }
                        if (row % 2 == 0)
                        {
                            for (index = 0; index < placesInOddSector + 2; index++, counterPlaces++)
                            {
                                place = alphabet[index].ToString();
                                Console.WriteLine($"{sector}{row}{place}");
                            }
                            continue;
                        }
                    }
                    break;
                }
                if(sector == lastSector)
                {
                    break;
                }
            }
            Console.WriteLine(counterPlaces);
        }
    }
}
