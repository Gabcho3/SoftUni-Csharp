using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        private Shop shop;

        [SetUp]
        public void SetUp()
        {
            smartphone = new Smartphone("Nokia x10", 100);
            shop = new Shop(3);
        }

        [Test]
        public void Test_ConstructorTakesCapacityAndSetsPrivateFieldForSmartphones()
        {
            Assert.AreEqual(3, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Test_IfCapacityIsLessThanZeroThrows()
        {
            TestDelegate testDelegate = () => shop = new Shop(-1);
            Assert.Throws<ArgumentException>(testDelegate);
        }

        [Test]
        public void Test_AddingExistingSmartphoneThrows()
        {
            shop.Add(smartphone);
            TestDelegate testDelegate = () => shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(testDelegate);
        }

        [Test]
        public void Test_IfThereIsNoSpaceInShopThrows()
        {
            shop = new Shop(0);
            TestDelegate testDelegate = () => shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(testDelegate);
        }

        [Test]
        public void Test_AddingSmartphoneIncreasesCount()
        {
            shop.Add(smartphone);
            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void Test_RemovingNotExistingSmartphoneThrows()
        {
            shop.Add(smartphone);
            TestDelegate testDelegate = () => shop.Remove("Iphone 12");
            Assert.Throws<InvalidOperationException>(testDelegate);
        }

        [Test]
        public void Test_RemovingSpartphoneDecreasesCount()
        {
            shop.Add(smartphone);
            shop.Remove("Nokia x10");
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Test_TestingNotExistingSmartphoneThrows()
        {
            shop.Add(smartphone);
            TestDelegate testDelegate = () => shop.TestPhone("Iphone 12", 20);
            Assert.Throws<InvalidOperationException>(testDelegate);
        }

        [Test]
        public void Test_TestingSmartphoneWithCurrentBatteryUsageLessThanTakenThrows()
        {
            shop.Add(smartphone);
            TestDelegate testDelegate = () => shop.TestPhone("Nokia x10", 110);
            Assert.Throws<InvalidOperationException>(testDelegate);
        }

        [Test]
        public void Test_TestingPhoneDecreasesItsBattery()
        {
            shop.Add(smartphone);
            shop.TestPhone("Nokia x10", 50);
            Assert.AreEqual(50, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void Test_ChargingNotExistingSmartphoneThrows()
        {
            shop.Add(smartphone);
            TestDelegate testDelegate = () => shop.ChargePhone("Iphone 12");
            Assert.Throws<InvalidOperationException>(testDelegate);
        }

        [Test]
        public void Test_ChargingSmartPhoneIncreasesItsBatteryToItsMaxCharge()
        {
            shop.Add(smartphone);
            shop.TestPhone("Nokia x10", 50);
            shop.ChargePhone("Nokia x10");
            Assert.AreEqual(100, smartphone.CurrentBateryCharge);
        }
    }
}