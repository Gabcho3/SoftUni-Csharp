namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        private const string testMake = "Audi";
        private const string testModel = "Q7";
        private const double testFuelConsumption = 22;
        private const double testFuelCapacity = 60;
        [SetUp]
        public void SetUp()
        {
            car = new Car(testMake, testModel, testFuelConsumption, testFuelCapacity);
        }

        [Test]
        public void Test_PublicConstructorWork()
        {
            Assert.AreEqual("Audi", car.Make, "Make getter do not work corectly");
            Assert.AreEqual("Q7", car.Model, "Model getter do not work corectly");
            Assert.AreEqual(22, car.FuelConsumption, "FuelConsumption getter do not work corectly");
            Assert.AreEqual(60, car.FuelCapacity, "FuelCapacity getter do not work corectly");
        }

        [Test]
        public void Test_PrivateConstructor()
        {
            Assert.AreEqual(0, car.FuelAmount, "FuelAmount getter do not work correctly");
        }

        [Test]
        public void Test_MakeSetterThrows()
        {
            TestDelegate testDelegate = () =>
            {
                new Car("", testModel, testFuelConsumption, testFuelCapacity);
                new Car(null, testModel, testFuelConsumption, testFuelCapacity);
            };
            Assert.Throws<ArgumentException>(testDelegate, "Can apply null or empty make");
        }

        [Test]
        public void Test_ModelSetterThrows()
        {
            TestDelegate testDelegate = () =>
            {
                new Car(testMake, "", testFuelConsumption, testFuelCapacity);
                new Car(testMake, null, testFuelConsumption, testFuelCapacity);
            };
            Assert.Throws<ArgumentException>(testDelegate, "Can apply null or empty model");
        }

        [Test]
        public void Test_FuelConsumptionSetterThrows()
        {
            TestDelegate testDelegate = () =>
            {
                new Car(testMake, testModel, 0, testFuelCapacity);
                new Car(testMake, testModel, -1, testFuelCapacity);
            };
            Assert.Throws<ArgumentException>(testDelegate, "Can apply 0 or negative fuelConsumption");
        }

        [Test]
        public void Test_FuelCapacitySetterThrows()
        {
            TestDelegate testDelegate = () =>
            {
                new Car(testMake, testModel, testFuelConsumption, 0);
                new Car(testMake, testMake, testFuelConsumption, -1);
            };
            Assert.Throws<ArgumentException>(testDelegate, "Can apply 0 or negative fuelCapacity");
        }

        [Test]
        public void Test_RefuelWorksProperly()
        {
            car.Refuel(30);
            Assert.AreEqual(30, car.FuelAmount, "Refuel does not work properly");
        }

        [Test]
        public void Test_TryingToRefuelNegativeFuelThrows()
        {
            TestDelegate testDelegate = () =>
            { car.Refuel(0); car.Refuel(-1); };
            Assert.Throws<ArgumentException>(testDelegate, "Can refuel 0 or negative fuel");
        }

        [Test]
        public void Test_TryingToRefuelMoreThanFuelCapacity()
        {
            car.Refuel(100);
            Assert.AreEqual(60, car.FuelAmount, "Can refuel more than fuelCapacity fuel");
        }

        [Test]
        public void Test_DriveWorksProperly()
        {
            car.Refuel(60);
            car.Drive(30);
            double fuelNeeded = (30.0 / 100) * car.FuelConsumption; //6.6
            double fuelExpected = 60 - fuelNeeded;
            Assert.AreEqual(fuelExpected, car.FuelAmount, "Drive does not work properly");
        }

        [Test]
        public void Test_DriveMoreThanPossibleThrows()
        {
            TestDelegate testDelegate = () => car.Drive(10);
            Assert.Throws<InvalidOperationException>(testDelegate, "Can drive more than possible");
        }
    }
}