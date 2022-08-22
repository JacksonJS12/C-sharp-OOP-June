namespace BookigApp.Tests
{
    using FrontDeskApp;
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class BookingTests
    {
        [Test]
        [TestCase(1, 30)]
        public void ConstructorShouldWokrsCorrectly(int bookingNumber, int residenceDuration)
        {
            Room room = new Room(10, 10);
            Booking booking = new Booking(bookingNumber, room, residenceDuration);

            Assert.AreEqual(bookingNumber, booking.BookingNumber);
            Assert.AreEqual(room, booking.Room);
            Assert.AreEqual(residenceDuration, booking.ResidenceDuration);
        }

    }
}
