using NUnit.Framework;
using System.Linq;

namespace RobotFactory.Tests
{
    [TestFixture]
    public class Tests
    {
        private Factory factory;
        private Robot robot;
        private Supplement supplement;

        [SetUp]
        public void Setup()
        {
            supplement = new Supplement("Protein", 10);
            robot = new Robot("A-30", 100, 30);
            factory = new Factory("Gabiland", 10);
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.AreEqual("Gabiland", factory.Name);
            Assert.AreEqual(10, factory.Capacity);
            Assert.AreEqual(0, factory.Robots.Count);
            Assert.AreEqual(0, factory.Supplements.Count);
        }

        [Test]
        public void Test_AddingRobotIfCapacityIsMoreThanRobotsCount()
        {
            string returned = factory.ProduceRobot(robot.Model, robot.Price, robot.InterfaceStandard);
            Assert.AreEqual(1, factory.Robots.Count);
            Assert.AreEqual($"Produced --> Robot model: {robot.Model} IS: {robot.InterfaceStandard}, Price: {robot.Price:f2}", returned);
        }

        [Test]
        public void Test_IsCapacityIsBelowRobotsCountReturns()
        {
            factory = new Factory("Vikiland", 0);
            string returned = factory.ProduceRobot(robot.Model, robot.Price, robot.InterfaceStandard);
            Assert.AreEqual("The factory is unable to produce more robots for this production day!", returned);
        }

        [Test]
        public void Test_AddingSupplyReturnsSupplimentToString()
        {
            string returned = factory.ProduceSupplement(supplement.Name, supplement.InterfaceStandard);
            Assert.AreEqual(1, factory.Supplements.Count);
            Assert.AreEqual($"Supplement: {supplement.Name} IS: {supplement.InterfaceStandard}", returned);
        }

        [Test]
        public void Test_AddingUnexistingSupplimetReturnsFalse()
        {
            Assert.IsFalse(factory.UpgradeRobot(robot, supplement));
        }

        [Test]
        public void Test_AddingSupplimentIncreaseRobotSupplimentsCount()
        {
            factory.ProduceRobot(robot.Model, robot.Price, robot.InterfaceStandard);
            factory.ProduceSupplement(supplement.Name, robot.InterfaceStandard);
            bool isTrue = factory.UpgradeRobot(robot, new Supplement(supplement.Name, robot.InterfaceStandard));
            Assert.AreEqual(1, robot.Supplements.Count);
            Assert.IsTrue(isTrue);
        }

        [Test]
        public void Test_SellingRobotWithPrice()
        {
            factory.ProduceRobot(robot.Model, robot.Price, robot.InterfaceStandard);
            Robot returnedRobot1 = factory.SellRobot(100);
            Robot returnedRobot2 = factory.SellRobot(120);
            Assert.AreEqual(robot.ToString(), returnedRobot1.ToString());
            Assert.AreEqual(robot.ToString(), returnedRobot2.ToString());
        }
    }
}