using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        // Implement unit tests here
        [Test]
        public void Test_Athlete_Creation()
        {
            Athlete athlete = new Athlete("Peshkata");

            Assert.AreEqual("Peshkata", athlete.FullName);
            Assert.AreEqual(false, athlete.IsInjured);
        }

        [Test]

        public void Test_Gym_Creation()
        {
            Gym gym = new Gym("Qki sme", 15);

            Assert.AreEqual("Qki sme", gym.Name);
            Assert.AreEqual(15, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void Test_Gym_Creation_With_Null_Name_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym(null, 15);

            });
        }
    }
}
