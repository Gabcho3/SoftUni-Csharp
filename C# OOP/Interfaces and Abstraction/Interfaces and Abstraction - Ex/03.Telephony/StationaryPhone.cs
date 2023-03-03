using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public void Dialing(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
