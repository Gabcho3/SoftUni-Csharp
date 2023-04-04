using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Planet planet;
            private Weapon weapon;

            [SetUp]
            public void SetUp()
            {
                weapon = new Weapon("AK-47", 400, 100);
                planet = new Planet("Gabilandia", 1000);
            }

            [Test]
            public void Test_WeaponConstructorWorksProperly()
            {
                Assert.AreEqual("AK-47", weapon.Name);
                Assert.AreEqual(400, weapon.Price);
                Assert.AreEqual(100, weapon.DestructionLevel);
            }

            [Test]
            public void Test_NegativeWeaponPriceThrows()
            {
                TestDelegate testDelegate = () => new Weapon("Scar", -1, 2);
                Assert.Throws<ArgumentException>(testDelegate);
            }

            [Test]
            public void Test_WeaponIsNuclearIfDesctructionLevelIs10OrGreater()
            {
                Assert.IsTrue(weapon.IsNuclear);
                Assert.IsFalse(new Weapon("Ak-47", 10, 5).IsNuclear);
            }

            [Test]
            public void Test_IncreaseDesctuctionLevelWorksProperly()
            {
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(101, weapon.DestructionLevel);
            }

            [Test]
            public void Test_PlanetConstructorWorksProperly()
            {
                List<Weapon> weapons = new List<Weapon>();
                Assert.AreEqual("Gabilandia", planet.Name);
                Assert.AreEqual(1000, planet.Budget);
                Assert.AreEqual(weapons, planet.Weapons);
            }

            [Test]
            public void Test_NullOrEmptySpacePlanetNameThrows()
            {
                TestDelegate testDelegate = () => { new Planet(null, 1); new Planet(string.Empty, 2); };
                Assert.Throws<ArgumentException>(testDelegate);
            }

            [Test]
            public void Test_NegativeBudgetThrows()
            {
                TestDelegate testDelegate = () => new Planet("Gabilandia", -1);
                Assert.Throws<ArgumentException>(testDelegate);
            }

            [Test]
            public void Test_MilitaryPowerRatioGetterCalculatesProperly()
            {
                planet.AddWeapon(weapon);
                Assert.AreEqual(weapon.DestructionLevel, planet.MilitaryPowerRatio);
            }

            [Test]
            public void Test_ProfitAddsAmountToBudget()
            {
                planet.Profit(1000);
                Assert.AreEqual(2000, planet.Budget);
            }

            [Test]
            public void Test_SpendingMoreMoneyThrows()
            {
                TestDelegate testDelegate = () => planet.SpendFunds(5000);
                Assert.Throws<InvalidOperationException>(testDelegate);
            }

            [Test]
            public void Test_SpendingMoneyDecreasesBudget()
            {
                planet.SpendFunds(500);
                Assert.AreEqual(500, planet.Budget);
            }

            [Test]
            public void Test_TryingToAddExistingWeaponThrows()
            {
                planet.AddWeapon(weapon);
                TestDelegate testDelegate = () => planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(testDelegate);
            }

            [Test]
            public void Test_AddingWeaponIncreasesWeaponsCount()
            {
                planet.AddWeapon(weapon);
                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void Test_RemovingWeaponDecreasesWeaponsCount()
            {
                planet.AddWeapon(weapon);
                planet.AddWeapon(new Weapon("Scar", 500, 200));
                planet.RemoveWeapon(weapon.Name);
                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void Test_UpgradingUnexistingWeaponThrows()
            {
                planet.AddWeapon(weapon);
                TestDelegate testDelegate = () => planet.UpgradeWeapon("M416");
                Assert.Throws<InvalidOperationException>(testDelegate);
            }

            [Test]
            public void Test_UpgradingWeaponIncreasesDestructionLevel()
            {
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);
                Assert.AreEqual(101, planet.Weapons.First().DestructionLevel);
            }

            [Test]
            public void Test_DesctructingStrongerOpponentThrows()
            {
                Planet testPlanet = new Planet("Victoria", 3000);
                testPlanet.AddWeapon(new Weapon("Scar", 500, 200));
                TestDelegate testDelegate = () => planet.DestructOpponent(testPlanet);
                Assert.Throws<InvalidOperationException>(testDelegate);
            }

            [Test]
            public void Test_DestructingWeakerOpponentReturns()
            {
                planet.AddWeapon(weapon);
                string returns = planet.DestructOpponent(new Planet("Bul", 100));
                Assert.AreEqual("Bul is destructed!", returns);
            }
        }
    }
}
