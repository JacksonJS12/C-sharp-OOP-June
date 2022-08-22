namespace BookigApp.Tests
{
    using FrontDeskApp;
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class HotelTests
    {
        [Test]
        [TestCase("Hotel1", 5)]
        public void ConstructorShouldWork(string fullName, int category)
        {
            Hotel hotel = new Hotel(fullName, category);
            string expectedName = "Hotel1";
            int expectedCategory = 5;

            Assert.AreEqual(expectedName, hotel.FullName);
            Assert.AreEqual(expectedCategory, hotel.Category);
        }

        [Test]
        public void TestAddRoom()
        {
            Hotel hotel = new Hotel("TestHotel", 4);
            Room room = new Room(10, 5);

            hotel.AddRoom(room);

            int expectedCount = 1;
            int actualCount = hotel.Rooms.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase(2, 1, 4, 200, 4, 2, 3, 324)]
        public void TestBookRoom(int adults, int children, int residenceDuration, double budget,
                                 int adults1, int children1, int residenceDuration1, double budget1)
        {
            Hotel hotel = new Hotel("TestHotel", 5);
            Room room1 = new Room(10, 5);
            Room room2 = new Room(20, 10);
            Room room3 = new Room(35, 12);
            Room room4 = new Room(50, 31);

            hotel.AddRoom(room1);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);
            hotel.AddRoom(room4);

            hotel.BookRoom(adults, children, residenceDuration, budget);
            hotel.BookRoom(adults1, children1, residenceDuration1, budget1);

            int bookingsExpectedCount = 8;
            int bookingsActualCount = hotel.Bookings.Count;

            double expectedTurnover = 406;
            double actualTurnover = hotel.Turnover;

            Assert.AreEqual(bookingsExpectedCount, bookingsActualCount);
            Assert.AreEqual(expectedTurnover, actualTurnover);
        }
    }
}
