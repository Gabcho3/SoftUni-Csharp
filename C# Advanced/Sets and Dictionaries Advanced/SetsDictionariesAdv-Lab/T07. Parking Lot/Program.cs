using System;
using System.Collections.Generic;

namespace T07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parkingLot = new HashSet<string>();

            while (true)
            {
                string[] command = Console.ReadLine().Split(", ");
                switch (command[0])
                {
                    case "IN":
                        parkingLot.Add(command[1]);
                        break;
                    case "OUT":
                        parkingLot.Remove(command[1]);
                        break;
                    default: //END
                        if (parkingLot.Count == 0)
                            Console.WriteLine("Parking Lot is Empty");

                        else
                        {
                            foreach (var number in parkingLot)
                                Console.WriteLine(number);
                        }
                        return;
                }
            }
        }
    }
}
