using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Xml.Linq;

namespace VendingRetail.Tests
{
    public class Tests
    {
        private CoffeeMat coffeeMat;
        
        [SetUp]
        public void Setup()
        {
            coffeeMat = new CoffeeMat(80, 2);
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.AreEqual(80, coffeeMat.WaterCapacity);
            Assert.AreEqual(2, coffeeMat.ButtonsCount);
            Assert.AreEqual(0, coffeeMat.Income);
        }

        [Test]
        public void Test_IfWaterTankIsFullReturns()
        {
            coffeeMat = new CoffeeMat(0, 2);
            string returned = coffeeMat.FillWaterTank();
            string expected = "Water tank is already full!";
            Assert.AreEqual(expected, returned);
        }

        [Test]
        public void Test_FillingWaterTankReturns()
        {
            string returned = coffeeMat.FillWaterTank();
            string expected = $"Water tank is filled with 80ml";
            Assert.AreEqual(expected, returned);
        }

        [Test]
        public void Test_CanAddDrinkIDrinksAreLessThanButtons()
        {
            coffeeMat.AddDrink("coffee", 2);
            bool isAdded = coffeeMat.AddDrink("juice", 1);
            Assert.IsTrue(isAdded);
        }

        [Test]
        public void Test_CannotAddSameDrink()
        {
            coffeeMat.AddDrink("juice", 1);
            bool isAdded = coffeeMat.AddDrink("juice", 0.5);
            Assert.IsFalse(isAdded);
        }

        [Test]
        public void Test_AddingMoreDrinksThanButtonsCountReturnsFalse()
        {
            coffeeMat.AddDrink("water", 0.5);
            coffeeMat.AddDrink("appleJuice", 1);
            bool isAdded = coffeeMat.AddDrink("bananaJuice", 1.2);
            Assert.IsFalse(isAdded);
        }

        [Test]
        public void Test_IfWaterTankLevelIsLessThan80Returns()
        {
            string returned = coffeeMat.BuyDrink("coffee");
            string expected = "CoffeeMat is out of water!";
            Assert.AreEqual(expected, returned);
        }

        [Test]
        public void Test_CannotBuyDrinkWhichDoesNotExist()
        {
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink("juice", 1);

            string returned = coffeeMat.BuyDrink("coffee");
            string expected = "coffee is not available!";
            Assert.AreEqual(expected, returned);
        }

        [Test]
        public void Test_BuyingDrinkReturns()
        {
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink("juice", 1);

            string returned = coffeeMat.BuyDrink("juice");
            string expected = $"Your bill is 1.00$";
            Assert.AreEqual(expected, returned);
        }

        [Test]
        public void Test_CollectingIncomeReturns()
        {
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink("juice", 1);
            coffeeMat.BuyDrink("juice");

            Assert.AreEqual(1, coffeeMat.CollectIncome());
        }
    }
}