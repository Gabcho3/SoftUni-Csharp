using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        private int axeAttack;
        private int axeDurability;
        private int dummyHealth;
        private int dummyexpirience;

        [SetUp]
        public void SetUp()
        {
            axeAttack = 3;
            axeDurability = 5;
            dummyHealth = 6;
            dummyexpirience = 20;

            axe = new Axe(axeAttack, axeDurability);
            dummy = new Dummy(dummyHealth, dummyexpirience);
        }

        [Test]
        public void Test_AxesLosesDurabilityAfterAtack()
        {
            axe.Attack(dummy);
            Assert.AreEqual(4, axe.DurabilityPoints);
        }

        [Test]
        public void Test_AxeAttacksWithBrokenWeapon()
        {
            axeDurability -= 6;
            axe = new Axe(axeAttack, axeDurability);

            Assert.Catch<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }
    }
}