namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        private Person person;

        [SetUp]
        public void SetUp()
        {
            person = new Person(1, "Gabcho");
            database = new Database(new Person[1] {person});
        }

        [Test]
        public void Test_AddingRangeMoreThan16PopleThrows()
        {
            TestDelegate testDelegate = () => database = new Database(new Person[17]);
            Assert.Throws<ArgumentException>(testDelegate, "Can add range more than 16 people");
        }

        [Test]
        public void Test_CountIncreasesWhenAddingPerson()
        {
            database.Add(new Person(2, "Vikcho"));
            Assert.AreEqual(2, database.Count, "Count does not increases when adding a person");
        }

        [Test]
        public void Test_UserWithThisNameAlreadyExistsThrows()
        {
            Person person = new Person(2, "Gabcho");
            TestDelegate testDelegate = () => database.Add(person);
            Assert.Throws<InvalidOperationException>(testDelegate, "User with this name already exists");
        }

        [Test]
        public void Test_UserWithThisIdAlreadyExistsThrows()
        {
            Person person = new Person(1, "Vikcho");
            TestDelegate testDelegate = () => database.Add(person);
            Assert.Throws<InvalidOperationException>(testDelegate, "User with this id already exists");
        }

        [Test]
        public void Test_AddingMoreThan16PopleThrows()
        {
            int id = 2;
            for(char name = 'G'; name < 'G' + 15; name++, id++)
            {
                database.Add(new Person(id, name.ToString()));
            }

            TestDelegate testDelegate = () => database.Add(new Person(3, "Ivan"));
            Assert.Throws<InvalidOperationException>(testDelegate, "Can add more than 16 people");
        }

        [Test]
        public void Test_CountIncreasesWhenRemovingPerson()
        {
            database.Remove();
            Assert.AreEqual(0, database.Count, "Count does not increases when removing a person");
        }

        [Test]
        public void Test_RemovingFromEmptyDatabaseThrows()
        {
            database = new Database(new Person[0]);
            TestDelegate testDelegate = () => database.Remove();
            Assert.Throws<InvalidOperationException>(testDelegate, "Can remove person from empty database");
        }

        [Test]
        public void Test_RemovingLastPerson()
        {
            person = new Person(2, "Vikcho");
            database.Add(person);
            database.Remove();

            TestDelegate testDelegate = () => database.FindById(2);
            Assert.Throws<InvalidOperationException>(testDelegate, "Removing do not work corectly");
        }

        [Test]
        public void Test_FindByUsernameReturnsCorrectPerson()
        {
            Person personToFind = database.FindByUsername("Gabcho");
            Assert.AreEqual(person, personToFind, "FindByUsername does not work properly");
        }

        [Test]
        public void Test_TryingToInvokFindByUsernameWithEmptyOrNullNameThrows()
        {
            TestDelegate testDelegate = () => { database.FindByUsername(string.Empty); database.FindByUsername(null); };
            Assert.Throws<ArgumentNullException>(testDelegate, "Can apply user with empty/null name");
        }

        [Test]
        public void Test_TryingToFindPersonByNameWhichDoesNotExistThrows()
        {
            TestDelegate testDelegate = () => database.FindByUsername("Gosho");
            Assert.Throws<InvalidOperationException>(testDelegate, "Can apply user which does not exists");
        }

        [Test]
        public void Test_FindByIdRetursCorrectPerson()
        {
            Person personToFind = database.FindById(1);
            Assert.AreEqual(person, personToFind);
        }

        [Test]
        public void Test_TryingToFindPersonWithNegativeIdThrows()
        {
            TestDelegate testDelegate = () => database.FindById(-1);
            Assert.Throws<ArgumentOutOfRangeException>(testDelegate, "Can apply negative id");
        }

        [Test]
        public void Test_TryingToFindPersonByIdWhichDoesNotExistsThrows()
        {
            TestDelegate testDelegate = () => database.FindById(2);
            Assert.Throws<InvalidOperationException>(testDelegate, "Can apply id which does not exists");
        }
    }
}