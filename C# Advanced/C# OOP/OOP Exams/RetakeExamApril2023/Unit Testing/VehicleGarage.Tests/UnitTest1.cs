using NUnit.Framework;
using System.Linq;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        private Vehicle vehicle;
        private Garage garage;

        [SetUp]
        public void Setup()
        {
            vehicle = new Vehicle("Audi", "RS7", "6969");
            garage = new Garage(5);
        }

        [Test]
        public void Test_ConstructorTakesCapacityAndSetsNewListOfVehicles()
        {
            Assert.AreEqual(5, garage.Capacity);
            Assert.AreEqual(0, garage.Vehicles.Count);
        }

        [Test]
        public void Test_AddingVehicleReturnsTrueAndIncreasesVehiclesCount()
        {
            Assert.IsTrue(garage.AddVehicle(vehicle));
            Assert.AreEqual(1, garage.Vehicles.Count);
        }

        [Test]
        public void Test_AddingVehicleReturnsFalseIfGarageIsFull()
        {
            garage = new Garage(0);
            Assert.IsFalse(garage.AddVehicle(vehicle));
        }

        [Test]
        public void Test_AddingSameVehicleReturnsFalse()
        {
            garage.AddVehicle(vehicle);
            Assert.IsFalse(garage.AddVehicle(vehicle));
        }

        [Test]
        public void Test_ChargingVehicleReturnVehiclesChargedCount()
        {
            garage.AddVehicle(vehicle);
            Assert.IsTrue(1 == garage.ChargeVehicles(200));
        }

        [Test]
        public void Test_DrivingVehicleDecreasesVehiclesBatteryLevel()
        {
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("6969", 50, false);
            Assert.AreEqual(50, garage.Vehicles.First().BatteryLevel);
        }

        [Test]
        public void Test_DrivingVehicleCanBeDamaged()
        {
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("6969", 50, true);
            Assert.IsTrue(garage.Vehicles.First().IsDamaged);
        }

        [Test]
        public void Test_CannotDriveDamagedVehicle()
        {
            vehicle.IsDamaged = true;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("6969", 50, false);
            Assert.AreEqual(100, garage.Vehicles.First().BatteryLevel);
        }

        [Test]
        public void Test_CaanotDriveVehicleIfBatteryDrainageIsMoreThan100()
        {
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("6969", 200, false);
            Assert.AreEqual(100, garage.Vehicles.First().BatteryLevel);
        }

        [Test]
        public void Test_CannotDriveVehicleIfBatteryDrainageIsMoreThanBatteryLevel()
        {
            vehicle.BatteryLevel = 50;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle("6969", 70, false);
            Assert.AreEqual(50, garage.Vehicles.First().BatteryLevel);
        }

        [Test]
        public void Test_RepairingDamagedVehiclesSetsIsDamageToFalse()
        {
            vehicle.IsDamaged = true;
            garage.AddVehicle(vehicle);
            string returnedText = garage.RepairVehicles();
            Assert.AreEqual("Vehicles repaired: 1", returnedText);
            Assert.IsFalse(garage.Vehicles.First().IsDamaged);
        }
    }
}