using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
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
        public void Test_DummyLossesHealthWhenIsAttacked()
        {
            axe.Attack(dummy);

            Assert.AreEqual(3, dummy.Health);
        }

        [Test]
        public void Test_DummyIsDeadThrows()
        {
            axe = new Axe(6, axeDurability);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
                axe.Attack(dummy);
            });
        }

        [Test]
        public void Test_DeadDummyCanGiveXpThrows()
        {
            dummy = new Dummy(1, 1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }

        [Test]
        public void Test_AliveDummyCannotGiveXp()
        {
            dummy = new Dummy(0, 1);

            Assert.IsTrue(dummy.GiveExperience() > 0);
        }
    }
}