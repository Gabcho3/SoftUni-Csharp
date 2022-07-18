using System;

namespace T06.Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int roomsOnFloor = int.Parse(Console.ReadLine());
            bool notBigApartment = true;
            
            for(int floor = floors; floor >= 1; floor--)
            {
                for(int room = 0; room < roomsOnFloor; room++)
                {
                    notBigApartment = true;
                    if(floor == floors || floors == 1)
                    {
                        notBigApartment = false;
                        Console.Write($"L{floor}{room} ");
                    }
                    if(floor % 2 == 0 && notBigApartment)
                    {
                        Console.Write($"O{floor}{room} ");
                    }
                    if(floor % 2 != 0 && notBigApartment)
                    {
                        Console.Write($"A{floor}{room} ");
                    }
                }
                    Console.WriteLine();
            }
        }
    }
}
