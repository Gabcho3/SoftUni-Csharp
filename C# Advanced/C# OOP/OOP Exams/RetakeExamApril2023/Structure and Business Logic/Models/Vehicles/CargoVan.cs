using System;
using System.Collections.Generic;
using System.Text;

namespace EDriveRent.Models.Vehicles
{
    public class CargoVan : Vehicle
    {
        private const double maxMileage = 180;

        public CargoVan(string brand, string model, string licensePlateNumber)
            : base(brand, model, maxMileage, licensePlateNumber) { }
    }
}
