using System;
using System.Collections.Generic;

namespace T08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var guests = new HashSet<string>();
            var VIP = new HashSet<string>();
            while(true)
            {
                string input = Console.ReadLine();

                if(input == "PARTY")
                {
                    while(true)
                    {
                        string guest = Console.ReadLine();

                        if(guests.Contains(guest))
                            guests.Remove(guest);

                        if (VIP.Contains(guest))
                            VIP.Remove(guest);

                        if(guest == "END")
                        {
                            Console.WriteLine(guests.Count + VIP.Count);

                            foreach (var person in VIP)
                                Console.WriteLine(person);

                            foreach (var person in guests)
                                Console.WriteLine(person);

                            return;
                        }
                    }
                }

                if (input[0] >= 48 && input[0] <= 57) //ASCII CODE OF 0 - 9
                    VIP.Add(input);

                else
                    guests.Add(input);
            }
        }
    }
}
