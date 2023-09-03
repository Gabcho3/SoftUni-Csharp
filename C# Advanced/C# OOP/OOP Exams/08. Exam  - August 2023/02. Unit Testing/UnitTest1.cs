using NUnit.Framework;

namespace VendingRetail.Tests
{
    public class Tests
    {
                
        [Test]
        public void CheckCoffeMatIsCreatedSuccessfully()
        {
            CoffeeMat coffeeMat = new CoffeeMat(2000, 6);

            Assert.That(2000, Is.EqualTo(coffeeMat.WaterCapacity));
            Assert.AreEqual(6, coffeeMat.ButtonsCount);
            Assert.IsNotNull(coffeeMat);
        }

        [Test]
        public void FillEmptyTank()
        {
            CoffeeMat coffeeMat = new CoffeeMat(2000, 6);

            string actualResult = coffeeMat.FillWaterTank();
            string expectedResult = "Water tank is filled with 2000ml";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FillFullTank()
        {
            CoffeeMat coffeeMat = new CoffeeMat(2000, 6);

            coffeeMat.FillWaterTank();
            string actualResult = coffeeMat.FillWaterTank();
            string expectedResult = "Water tank is already full!";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddDrinksToDictionary()
        {
            CoffeeMat coffeeMat = new CoffeeMat(2000, 6);

            bool isAdded = coffeeMat.AddDrink("Latte", 1.20);

            Assert.IsTrue(isAdded);
        }

        [Test]
        public void AddDrinksToExceedCapacityOfDictionaryDictionary()
        {
            CoffeeMat coffeeMat = new CoffeeMat(2000, 6);

            coffeeMat.AddDrink("Coffee", 0.80);
            coffeeMat.AddDrink("Macciato", 1.80);
            coffeeMat.AddDrink("Capuccino", 1.50);
            coffeeMat.AddDrink("Latte", 1.00);
            coffeeMat.AddDrink("Hot Chocolate", 1.60);
            coffeeMat.AddDrink("Milk", 0.90);
            coffeeMat.AddDrink("Tea", 0.60);
            coffeeMat.AddDrink("Hot Water", 0.30);
            bool isAdded = coffeeMat.AddDrink("Americano", 1.40);

            Assert.IsFalse(isAdded);
        }

        [Test]
        public void BuyExisingDrink()
        {
            CoffeeMat coffeeMat = new CoffeeMat(2000, 6);

            coffeeMat.AddDrink("Coffee", 0.80);
            coffeeMat.AddDrink("Macciato", 1.80);
            coffeeMat.AddDrink("Capuccino", 1.50);
            coffeeMat.AddDrink("Latte", 1.00);
            coffeeMat.AddDrink("Hot Chocolate", 1.60);

            coffeeMat.FillWaterTank();

            string actualResult = coffeeMat.BuyDrink("Latte");
            string expectedResult = "Your bill is 1.00$";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CofeeMatIsOutOfWater()
        {
            CoffeeMat coffeeMat = new CoffeeMat(2000, 6);

            coffeeMat.AddDrink("Coffee", 0.80);
            coffeeMat.AddDrink("Macciato", 1.80);
            coffeeMat.AddDrink("Capuccino", 1.50);
            coffeeMat.AddDrink("Latte", 1.00);
            coffeeMat.AddDrink("Hot Chocolate", 1.60);

            //coffeeMat.FillWaterTank();

            string actualResult = coffeeMat.BuyDrink("Latte");
            string expectedResult = "CoffeeMat is out of water!";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TryToBuyUnavailableDrink()
        {
            CoffeeMat coffeeMat = new CoffeeMat(2000, 6);

            coffeeMat.AddDrink("Coffee", 0.80);
            coffeeMat.AddDrink("Macciato", 1.80);

            coffeeMat.FillWaterTank();

            string actualResult = coffeeMat.BuyDrink("Latte");
            string expectedResult = "Latte is not available!";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CollectIncome()
        {
            CoffeeMat coffeeMat = new CoffeeMat(2000, 6);

            coffeeMat.FillWaterTank();

            coffeeMat.AddDrink("Coffee", 0.80);
            coffeeMat.AddDrink("Macciato", 1.80);
            coffeeMat.AddDrink("Capuccino", 1.50);
            coffeeMat.AddDrink("Latte", 1.00);
            coffeeMat.AddDrink("Hot Chocolate", 1.60);
            coffeeMat.AddDrink("Milk", 0.90);
            coffeeMat.AddDrink("Tea", 0.60);
            coffeeMat.AddDrink("Hot Water", 0.30);

            coffeeMat.BuyDrink("Coffee");
            coffeeMat.BuyDrink("Macciato");
            coffeeMat.BuyDrink("Capuccino");
            coffeeMat.BuyDrink("Latte");
            coffeeMat.BuyDrink("Milk");
            coffeeMat.BuyDrink("Hot Chocolate");

            double actualIncome = coffeeMat.Income;
            double income = coffeeMat.CollectIncome();
            double incomeAfterCollecting = coffeeMat.Income;

            Assert.AreEqual((double)income, actualIncome);
            Assert.That(7.60, Is.EqualTo(income));
            Assert.That(0, Is.EqualTo(incomeAfterCollecting));
        }

        [Test]
        public void CheckWaterConsuming()
        {
            CoffeeMat coffeeMat = new CoffeeMat(2000, 6);

            coffeeMat.FillWaterTank();

            coffeeMat.AddDrink("Coffee", 0.80);
            coffeeMat.AddDrink("Macciato", 1.80);
            coffeeMat.AddDrink("Capuccino", 1.50);
            coffeeMat.AddDrink("Latte", 1.00);
            coffeeMat.AddDrink("Hot Chocolate", 1.60);
            coffeeMat.AddDrink("Milk", 0.90);
            coffeeMat.AddDrink("Tea", 0.60);
            coffeeMat.AddDrink("Hot Water", 0.30);

            coffeeMat.BuyDrink("Coffee");
            coffeeMat.BuyDrink("Macciato");
            coffeeMat.BuyDrink("Capuccino");
            coffeeMat.BuyDrink("Latte");
            coffeeMat.BuyDrink("Milk");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            coffeeMat.BuyDrink("Hot Chocolate");
            string actualResult = coffeeMat.BuyDrink("Hot Chocolate");

            string expectedResult = "CoffeeMat is out of water!";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}