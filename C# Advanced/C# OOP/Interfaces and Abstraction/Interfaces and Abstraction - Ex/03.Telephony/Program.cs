using System;
using System.Linq;

namespace _03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SmartPhone smartPhone = new SmartPhone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in numbers)
            {
                if (number.Any(x => !char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                if (number.Length == 7)
                    stationaryPhone.Dialing(number);

                else if (number.Length == 10)
                    smartPhone.Calling(number);
            }

            foreach (var url in urls)
            {
                if (url.Any(x => char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }

                smartPhone.Browsing(url);
            }
        }
    }
}
