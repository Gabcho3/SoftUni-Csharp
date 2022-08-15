using System;

namespace T07._TheatrePromotion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var typeDay = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var price = 0;
            bool error = false;
            switch(typeDay)
            {
                case "Weekday":
                    if (age >= 0 && age <= 18 || age > 64 && age <= 122) price = 12;
                    else if (age > 18 && age <= 64) price = 18;
                    else error = true;
                        break;
                case "Weekend":
                    if (age >= 0 && age <= 18 || age > 64 && age <= 122) price = 15;
                    else if (age > 18 && age <= 64) price = 20;
                    else  error = true;
                    break;
                case "Holiday":
                    if (age >= 0 && age <= 18) price = 5;
                    else if (age > 18 && age <= 64) price = 12;
                    else if (age > 64 && age <= 122) price = 10;
                    else error = true;
                    break;
            }
            if (error) Console.WriteLine("Error!");
            else Console.WriteLine($"{price}$");
        }
    }
}
