namespace Aquariums
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class FishTest
    {
        [Test]
        [TestCase("Fish1")]
        [TestCase("Fish2")]
        [TestCase("Nemo")]
        public void TestIfConstructorSetsNameCorrectly(string name)
        {
            Fish fish = new Fish(name);

            Assert.AreEqual(fish.Name, name);
        }

        [Test]
        public void TestIfConstructorSetAvilableCorrectly()
        {
            string expectedName = "Fish";
            Fish fish = new Fish("Fish");

            Assert.AreEqual(fish.Name, expectedName);
            Assert.IsTrue(fish.Available);
        }
    }
}
