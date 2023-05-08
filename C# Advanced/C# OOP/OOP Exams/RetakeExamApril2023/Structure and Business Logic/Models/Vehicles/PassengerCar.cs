using System;
using System.Collections.Generic;
using System.Text;

namespace EDriveRent.Models.Vehicles
{
    public class PassengerCar : Vehicle
    {
        private const double maxMileage = 450 - 5;

        public PassengerCar(string brand, string model, string licensePlateNumber)
            : base(brand, model, maxMileage, licensePlateNumber) { }
    }
}
