using System;
using System.Collections.Generic;

namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new Car("Skoda", "Fabia", 65, "CC1856BG");
            var car2 = new Car("Audi", "A3", 110, "EB8787MN");
            var car3 = new Car("BMW", "8", 130, "CA1111CA");
            var car4 = new Car("Lamborghini", "Urus", 260, "CB1111CB");

            Console.WriteLine(car.ToString());
            //Make: Skoda
            //Model: Fabia
            //HorsePower: 65
            //RegistrationNumber: CC1856BG

            var parking = new Parking(3);
            Console.WriteLine(parking.AddCar(car));
            //Successfully added new car Skoda CC1856BG

            Console.WriteLine(parking.AddCar(car));
            //Car with that registration number, already exists!

            Console.WriteLine(parking.AddCar(car2));
            //Successfully added new car Audi EB8787MN

            Console.WriteLine(parking.AddCar(car3));
            //Successfully added new car BMW CA1111CA

            Console.WriteLine(parking.AddCar(car4));
            //Parking is full!

            Console.WriteLine(parking.GetCar("EB8787MN").ToString());
            //Make: Audi
            //Model: A3
            //HorsePower: 110
            //RegistrationNumber: EB8787MN

            Console.WriteLine(parking.RemoveCar("1111"));
            //Car with that registration number, doesn't exist!

            parking.RemoveSetOfRegistrationNumber(new List<string>() { "CC1856BG", "CA1111CA" });

            Console.WriteLine(parking.RemoveCar("EB8787MN"));
            //Successfullyremoved EB8787MN

            Console.WriteLine(parking.Count); //0

        }
    }
}
