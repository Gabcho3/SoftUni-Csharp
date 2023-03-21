namespace FightingArena.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        private const string name = "Gabcho";
        private const int damage = 50;
        private const int hp = 100;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior(name, damage, hp);
        }

        [Test]
        public void Test_ConstructorWorkProperly()
        {
            Assert.AreEqual(name, warrior.Name, "Name getter does not work properly");
            Assert.AreEqual(damage, warrior.Damage, "Damage getter does not work properly");
            Assert.AreEqual(hp, warrior.HP, "HP getter does not work properly");
        }

        [Test]
        public void Test_NameSetterThrows()
        {
            TestDelegate testDelegate = () =>
            {
                new Warrior(null, damage, hp);
                new Warrior(" ", damage, hp);
                new Warrior(string.Empty, damage, hp);
            };
            Assert.Throws<ArgumentException>(testDelegate, "Name setter does not work properly");
        }

        [Test]
        public void Test_DamageSetterThrows()
        {
            TestDelegate testDelegate = () =>
            {
                new Warrior(name, 0, hp);
                new Warrior(name, -1, hp);
            };
            Assert.Throws<ArgumentException>(testDelegate, "Damage setter does not work properly");
        }

        [Test]
        public void Test_HpSetterThrows()
        {
            TestDelegate testDelegate = () =>
            {
                new Warrior(name, damage, -1);
            };
            Assert.Throws<ArgumentException>(testDelegate, "HP setter does not work properly");
        }

        [Test]
        public void Test_HpIsLessOrEqualThanMinHpThrows()
        {
            Warrior testWarrior = new Warrior(name, damage, 30);
            TestDelegate testDelegate = () =>
            {
                warrior.Attack(new Warrior("Viki", 10, 100));
                testWarrior.Attack(new Warrior("Viki", 10, 100));
            };
            Assert.Throws<InvalidOperationException>(testDelegate, "Can attack with HP less/equal than minimum HP");
        }

        [Test]
        public void Test_EnemyHpIsLessOrEqualThanMinHpThrows()
        {
            TestDelegate testDelegate = () =>
            {
                warrior.Attack(new Warrior("Viki", 10, 3));
                warrior.Attack(new Warrior("Viki", 10, 30));
            };
            Assert.Throws<InvalidOperationException>(testDelegate, "Can attack enemy with HP less/equal than minimum HP");
        }

        [Test]
        public void Test_TryingToAttackTooStrongerEnemyThrows()
        {
            TestDelegate testDelegate = () => warrior.Attack(new Warrior("Viki", 200, 3));
            Assert.Throws<InvalidOperationException>(testDelegate, "Can attack stronger enemy");
        }

        [Test]
        public void Test_SettingEnemyHpToZeroIfDamageIsBigger()
        {
            Warrior enemy = new Warrior("Georgi", 10, 40);
            warrior.Attack(enemy);
            Assert.AreEqual(0, enemy.HP, "Enemy HP does not set to 0, if damage is more than enemy HP");
        }

        [Test]
        public void Test_EnemyHpIncreasesAfterAtacking()
        {
            Warrior enemy = new Warrior("Georgi", 10, 200);
            warrior.Attack(enemy);
            Assert.AreEqual(150, enemy.HP, "Enemy HP does not increase");
        }

        [Test]
        public void Test_HpIncreasesAfterAtacking()
        {
            warrior.Attack(new Warrior("Viki", 20, 200));
            Assert.AreEqual(80, warrior.HP);
        }
    }
}