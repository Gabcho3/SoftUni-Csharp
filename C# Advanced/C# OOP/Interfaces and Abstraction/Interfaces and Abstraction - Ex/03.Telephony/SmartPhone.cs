using _03.Telephony;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class SmartPhone : ISmartPhone
    {
        public void Calling(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }

        public void Browsing (string url)
        {
            Console.WriteLine($"Browsing: {url}!");
        }
    }
}
