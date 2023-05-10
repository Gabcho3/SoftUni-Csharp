using NUnit.Framework;
using System.Linq;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        private Vehicle vehicle;
        private Garage garage;

        [SetUp]
        public void SetUp()
        {
            vehicle = new Vehicle("Audi", "RS7", "6969");
            garage = new Garage(3);
        }

        [Test]
        public void Test_ConstructorWorksProperly()
        {
            Assert.AreEqual(3, garage.Capacity, "Constructor does not set capacity");
            Assert.AreEqual(0, garage.Vehicles.Count, "Constructor does not set new List of Vehicles");
        }

        [Test]
        public void Test_VehicleConstructorWorksProperly()
        {
            Assert.AreEqual("Audi", vehicle.Brand, "Vehicle Constructor does not set Brand properly");
            Assert.AreEqual("RS7", vehicle.Model, "Vehicle Constructor does not set Model properly");
            Assert.AreEqual("6969", vehicle.LicensePlateNumber, "Vehicle Constructor does not set LicensePlateNumber properly");
            Assert.AreEqual(100, vehicle.BatteryLevel, "Vehicle Constructor does not set BatteryLevel to 100");
            Assert.IsFalse(vehicle.IsDamaged, "Vehicle Constructor does not set that car is damaged to false");
        }

        [Test]
        public void Test_AddingVehicleIncreasesVehiclesCountAndReturnsTrue()
        {
            bool isTrue = garage.AddVehicle(vehicle);
            Assert.IsTrue(isTrue, "Adding Vehicle returns false");
            Assert.AreEqual(1, garage.Vehicles.Count, "Adding vehicle increases Vehicles count");
        }

        [Test]
        public void Test_AddingVehicleWithExistingNumberRetursFalse()
        {
            garage.AddVehicle(vehicle);
            Assert.IsFalse(garage.AddVehicle(new Vehicle("BMW", "x10", "6969")), "Can add vehicle with the same number");
        }

        [Test]
        public void Test_NoMoreSpaceInGarageReturnsFalse()
        {
            garage.Capacity = 1;
            garage.AddVehicle(vehicle);
            Assert.IsFalse(garage.AddVehicle(new Vehicle("Lambo", "Eco", "0303")), "Can add vehicle when there is no space");
        }

        [Test]
        public void Test_DrivingVehicleDecreasesItsBatteryLevel()
        {
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("6969", 99, false);
            Assert.AreEqual(1, vehicle.BatteryLevel, "Driving vehicle does not decreas its Battery Level");
        }

        [Test]
        public void Test_DrivingVehicleCanOccureAccident()
        {
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("6969", 50, true);
            Assert.IsTrue(vehicle.IsDamaged, "Cannot occure accident while driving");
        }

        [Test]
        public void Test_CannotDriveDamagedVehicle()
        {
            vehicle.IsDamaged = true;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("6969", 90, false);
            Assert.AreEqual(100, vehicle.BatteryLevel, "Can drive damaged vehicle");
        }

        [Test]
        public void Test_CannotDriveVehicleIfBatteryDrainageIsMoreThan100()
        {
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("6969", 110, false);
            Assert.AreEqual(100, vehicle.BatteryLevel, "Can drive vehicle if Battery Drainage is more than 100");
        }

        [Test]
        public void Test_CannotDriveVehicleIfBatteryDrainageIsMoreThanVehicleBatteryLevel()
        {
            vehicle.BatteryLevel = 90;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("6969", 91, false);
            Assert.AreEqual(90, vehicle.BatteryLevel, "Can drive vehicle is Battery Drainage is more than vehicle's Battery Level");
        }

        [Test]
        public void Test_ChargingVehiclesSetVehiclesBatteryLevelTo100AndReturnsTheirsCount()
        {
            vehicle.BatteryLevel = 50;
            garage.AddVehicle(vehicle);

            //If battery level is more than vehicles' battery levels
            Assert.AreEqual(1, garage.ChargeVehicles(100), "Charging vehicles does not return charged vehicles count properly");
            Assert.AreEqual(100, vehicle.BatteryLevel, "Charging vehicle does not set its Battery Level to 100");

            vehicle.BatteryLevel = 50;

            //If battery level is equal to vehicles' battery level
            Assert.AreEqual(1, garage.ChargeVehicles(50), "Charging vehicles does not return charged vehicles count properly");
        }

        [Test]
        public void Test_IfBatteryLevelIsLessThanVehiclesLevelsReturnsZero()
        {
            vehicle.BatteryLevel = 50;
            garage.AddVehicle(vehicle);
            Assert.AreEqual(0, garage.ChargeVehicles(40), "Can charge vehicles if Battery Level is more than vehicles' Battery Level");
        }

        [Test]
        public void Test_RepairingVehiclesReturnsMessage()
        {
            vehicle.IsDamaged = true;
            garage.AddVehicle(vehicle);
            string messageReturned = garage.RepairVehicles();
            Assert.AreEqual(messageReturned, $"Vehicles repaired: 1", "Repairing vehicles returns the right message");
            Assert.IsFalse(vehicle.IsDamaged, "Repairing works properly");
        }
    }
}