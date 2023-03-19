namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database(new int[0]);
        }

        [Test]
        public void Test_StoringCapacityIsExactly16Throws()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database = new Database(new int[17]);
            });
        }

        [Test]
        public void Test_AddingElementIncreasesCount()
        {
            database.Add(1);
            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void Test_AddingMoreThan16ElementsThrows()
        {
            database = new Database(new int[16]);
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(0);
            });
        }

        [Test]
        public void Test_RemovingLastElement()
        {
            database = new Database(new int[2] { 1, 2 });
            database.Remove();
            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void Test_RemovingAnElementFromEmptyDatabaseThrows()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void Test_FetchReturnsAnArray()
        {
            database = new Database(new int[16]);
            Assert.AreEqual(new int[16], database.Fetch());
        }
    }
}
