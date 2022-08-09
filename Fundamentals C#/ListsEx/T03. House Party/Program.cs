using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commands = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();
            bool isInList = false;

            for(int i = 0; i < commands; i++)
            {
                string[] guestInfo = Console.ReadLine().Split().ToArray();
                isInList = guests.Contains(guestInfo[0]);

                if(guestInfo[2] == "going!")
                {
                    if (!isInList)
                        guests.Add(guestInfo[0]);

                    else
                        Console.WriteLine(guestInfo[0] + " is already in the list!");
                }
                else
                {
                    if (isInList)
                        guests.Remove(guestInfo[0]);

                    else
                        Console.WriteLine(guestInfo[0] + " is not in the list!");
                }
            }

            for (int i = 0; i < guests.Count; i++)
            {
                Console.WriteLine(guests[i]);
            }
        }
    }
}
