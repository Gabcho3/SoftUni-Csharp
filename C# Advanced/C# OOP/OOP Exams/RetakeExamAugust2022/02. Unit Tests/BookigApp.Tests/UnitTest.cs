using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Room room;
        private Hotel hotel;
        [SetUp]
        public void Setup()
        {
            room = new Room(4, 80);
            hotel = new Hotel("Gabiland", 5);
        }

        [Test]
        public void Test_ConstructorWorksProperly()
        {
            List<Room> rooms = new List<Room>();
            List<Booking> bookings = new List<Booking>();

            Assert.AreEqual("Gabiland", hotel.FullName);
            Assert.AreEqual(5, hotel.Category);
            Assert.AreEqual(rooms, hotel.Rooms);
            Assert.AreEqual(bookings, hotel.Bookings);
        }

        [Test]
        public void Test_FullNameIsNullOrWhiteSpaceThrows()
        {
            TestDelegate testDelegate = () => { new Hotel(null, 5); new Hotel("  ", 5); };
            Assert.Throws<ArgumentNullException>(testDelegate);
        }

        [Test]
        public void Test_SetCategoryLessThan1OrGreaterThan5Throws()
        {
            TestDelegate testDelegate = () => { new Hotel("Gabiland", 0); new Hotel("Gabiland", 6); };
            Assert.Throws<ArgumentException>(testDelegate);
        }

        [Test]
        public void Test_TurnoverSetterWorksProperly()
        {
            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        public void Test_AddingRoomWorksProperly()
        {
            hotel.AddRoom(room);
            Assert.IsTrue(hotel.Rooms.Contains(room));
        }

        [Test]
        public void Test_TryingToBookWithNoAdultsThrows()
        {
            TestDelegate testDelegate = () => hotel.BookRoom(0, 1, 7, 400);
            Assert.Throws<ArgumentException>(testDelegate);
        }

        [Test]
        public void Test_TryingToBookWithNegativeCountOfChildrenThrows()
        {
            TestDelegate testDelegate = () => hotel.BookRoom(1, -1, 7, 400);
            Assert.Throws<ArgumentException>(testDelegate);
        }

        [Test]
        public void Test_TryingToBookWithNegativeOrZeroDurationThrows()
        {
            TestDelegate testDelegate = () => hotel.BookRoom(1, 1, 0, 400);
            Assert.Throws<ArgumentException>(testDelegate);
        }

        [Test]
        public void Test_BookingWorksProperly()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(2, 2, 2, 200);
            Assert.AreEqual(1, hotel.Bookings.Count);
            Assert.AreEqual(160, hotel.Turnover);
        }
    }
}