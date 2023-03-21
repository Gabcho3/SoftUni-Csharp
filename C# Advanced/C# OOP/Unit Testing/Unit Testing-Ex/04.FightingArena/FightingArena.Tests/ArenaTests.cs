namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void Test_Constructor()
        {
            
            Assert.AreEqual(0, arena.Count, "Constructor does not work properly");
            Assert.AreEqual(typeof(List<Warrior>), arena.Warriors.GetType());
        }

        [Test]
        public void Test_EnrollWorksProperly()
        {
            Warrior warrior = new Warrior("Gabcho", 100, 50);
            arena.Enroll(warrior);
            Assert.AreEqual(warrior, arena.Warriors.First(), "Enroll does not work properly");
            Assert.AreEqual(1, arena.Count, "Enroll does not work properly");
        }

        [Test]
        public void Test_TryingToEnrollExistedThrows()
        {
            arena.Enroll(new Warrior("Gabcho", 100, 50));
            TestDelegate testDelegate = () =>
            {
                arena.Enroll(new Warrior("Gabcho", 10, 100));
            };
            Assert.Throws<InvalidOperationException>(testDelegate, "Can enroll existed warrior");
        }

        [Test]
        public void Test_TryingToAtackNotExistedWarriorThrows()
        {
            Warrior attacker = new Warrior("Gabcho", 100, 50);
            Warrior defender = new Warrior("Vikcho", 10, 100);

            TestDelegate testDelegate = () => arena.Fight("Gabcho", "Ivan");
            Assert.Throws<InvalidOperationException>(testDelegate, "Can attack not existed warrior");
        }

        [Test]
        public void Test_TryingToFightWithNoExistedAttacker()
        {
            Warrior attacker = new Warrior("Gabcho", 100, 50);
            Warrior defender = new Warrior("Vikcho", 10, 100);

            TestDelegate testDelegate = () => arena.Fight("Sofia", "Vikcho");
            Assert.Throws<InvalidOperationException>(testDelegate, "Can fight with not existed warrior");
        }
    }
}
