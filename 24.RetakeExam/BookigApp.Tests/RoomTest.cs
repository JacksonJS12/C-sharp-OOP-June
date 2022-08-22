namespace BookigApp.Tests
{
    using FrontDeskApp;
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class RoomTests
    {
        [Test]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(999)]
        public void TestIfConstructorSetsBedCapacityCorrectly(int bedCapacity)
        {
            Room room = new Room(bedCapacity, 10);

            Assert.AreEqual(room.BedCapacity, bedCapacity);
        }
        [Test]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(999)]
        public void TestIfConstructorSetsPricePerNightCorrectly(double pricePerNight)
        {
            Room room = new Room(20, pricePerNight);

            Assert.AreEqual(room.PricePerNight, pricePerNight);
        }
    }
}