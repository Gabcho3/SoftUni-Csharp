using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {
            private Car car;
            private Garage garage;
            private TestDelegate testDelegate;

            [SetUp]
            public void SetUp()
            {
                car = new Car("Audi", 3);
                garage = new Garage("Gab", 3);
            }

            [Test]
            public void Test_ConstructorWorksProperly()
            {
                Assert.AreEqual("Gab", garage.Name);
                Assert.AreEqual(3, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void Test_NameIsNullOrEmptyThrows()
            {
                testDelegate = () => { new Garage(null, 3); new Garage(string.Empty, 3); };
                Assert.Throws<ArgumentNullException>(testDelegate);
            }

            [Test]
            public void Test_SetNegativeOrZeroMechanicsAvailableThrows()
            {
                testDelegate = () => { new Garage("Gab", 0); new Garage("Gab", -1); };
                Assert.Throws<ArgumentException>(testDelegate);
            }

            [Test]
            public void Test_AddingCarWhenNoAvailableMechanicsThrows()
            {
                garage = new Garage("Vik", 1);
                garage.AddCar(car);
                testDelegate = () => garage.AddCar(car);
                Assert.Throws<InvalidOperationException>(testDelegate);
            }

            [Test]
            public void Test_AddingCarIncreasesCountOfCars()
            {
                garage.AddCar(car);
                Assert.AreEqual(1, garage.CarsInGarage);
            }

            [Test]
            public void Test_FixingUnExistingCarThrows()
            {
                garage.AddCar(car);
                testDelegate = () => garage.FixCar("BMW");
                Assert.Throws<InvalidOperationException>(testDelegate);
            }

            [Test]
            public void Test_FixingCarSetCarIssuesToZero()
            {
                garage.AddCar(car);
                Car fixedCar = garage.FixCar("Audi");
                Assert.AreEqual(0, fixedCar.NumberOfIssues);
            }

            [Test]
            public void Test_RemovingZeroCarsThrows()
            {
                garage.AddCar(car);
                testDelegate = () => garage.RemoveFixedCar();
                Assert.Throws<InvalidOperationException>(testDelegate);
            }

            [Test]
            public void Test_RemovingCarsDecresesCarsCount()
            {
                garage.AddCar(car);
                garage.FixCar("Audi");
                garage.RemoveFixedCar();
                Assert.AreEqual(0, garage.CarsInGarage);
            }

            [Test]
            public void Test_ReportReturnsUnFixedCarsModel()
            {
                garage.AddCar(car);
                garage.AddCar(new Car("Lambo", 1));
                string expectingReturn = "There are 2 which are not fixed: Audi, Lambo.";
                Assert.AreEqual(expectingReturn, garage.Report());
            }
        }
    }
}