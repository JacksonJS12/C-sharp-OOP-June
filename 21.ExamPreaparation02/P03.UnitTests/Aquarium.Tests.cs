namespace Aquariums
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    [TestFixture]
    public class AquariumTests
    {
        [Test]
        [TestCase("Fish1", 1)]
        [TestCase("Fish2", 10)]
        [TestCase("Fish3", 999)]
        public void ConstructorShouldWokrsCorrectly(string name, int capacity)
        {
            Aquarium aquarium = new Aquarium(name, capacity);

            Assert.AreEqual(capacity, aquarium.Capacity);
            Assert.AreEqual(name, aquarium.Name);
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void InvalidName(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 1);
            },
            "Invalid aquarium name!");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-999)]
        [TestCase(int.MinValue)]
        public void InvalidCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("Fish", capacity);
            },
            "Invalid aquarium capacity!");
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        public void TestAddingFishWhenFree(int capacity)
        {
            var aquarium = new Aquarium("Fish2", capacity);
            Fish fish = new Fish("Fish1");

            aquarium.Add(fish);
            int expectedCount = 1;
            int actualCount = aquarium.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }


        [Test]
        public void TestAddingFihsWhenAquariumIsFull()
        {
            Aquarium aquarium = new Aquarium("fish", 2);
            Fish fish1 = new Fish("Fish1");
            Fish fish2 = new Fish("Fish2");

            aquarium.Add(fish2);
            aquarium.Add(fish1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish2);
            },
            "Aquarium is full!");

        }

        [Test]
        public void TestIfRemovingExistingFishWorks()
        {
            string fishName = "Fish1";
            Aquarium aquarium = new Aquarium("fish", 2);
            Fish fish1 = new Fish(fishName);
            Fish fish2 = new Fish("Fish2");

            aquarium.Add(fish2);
            aquarium.Add(fish1);

            aquarium.RemoveFish(fishName);

            int expectedCount = 1;
            int actualCount = aquarium.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestRemovingNonExistingFish()
        {
            string fishName = "NonExstent";

            Aquarium aquarium = new Aquarium("fish", 2);
            Fish fish1 = new Fish("Fish1");
            Fish fish2 = new Fish("Fish2");

            aquarium.Add(fish2);
            aquarium.Add(fish1);


            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish(fishName);
            },
            "Fish with the name NonExstent doesn't exist!"
            );
        }

        [Test]
        public void TestSellingExistingFish()
        {
            string fishForSell = "Fish1";

            Aquarium aquarium = new Aquarium("fish", 2);
            Fish fish1 = new Fish(fishForSell);
            Fish fish2 = new Fish("Fish2");

            aquarium.Add(fish2);
            aquarium.Add(fish1);

            Fish fish = aquarium.SellFish(fishForSell);

            Assert.IsFalse(fish.Available);
        }

        [Test]
        public void TestSellingNonExistingFish()
        {
            string fishForSell = "NonExistent";

            Aquarium aquarium = new Aquarium("Aquarium", 3);
            Fish fish1 = new Fish("Fish");
            Fish fish2 = new Fish("Fishy");

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                Fish fish = aquarium.SellFish(fishForSell);
            }, $"Fish with the name {fishForSell} doesn't exist!");
        }

        [Test]
        public void TaestReportWithLikeManyFishes()
        {
            Aquarium aquarium = new Aquarium("Aquarium", 3);
            Fish fish1 = new Fish("Fish1");
            Fish fish2 = new Fish("Fish2");

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            string actualReport = aquarium.Report();
            string expectedReport = "Fish available at Aquarium: Fish1, Fish2";

            Assert.AreEqual(expectedReport, actualReport);
        }

        [Test]
        public void TestReportWithOneFishe()
        {
            Aquarium aquarium = new Aquarium("Aquarium", 3);
            Fish fish1 = new Fish("Fish1");

            aquarium.Add(fish1);

            string actualReport = aquarium.Report();
            string expectedReport = "Fish available at Aquarium: Fish1";

            Assert.AreEqual(expectedReport, actualReport);
        }
        [Test]
        public void TestReportWithEmptyAquarium()
        {
            Aquarium aquarium = new Aquarium("Aquarium", 3);
          

            string actualReport = aquarium.Report();
            string expectedReport = "Fish available at Aquarium: ";

            Assert.AreEqual(expectedReport, actualReport);
        }
        
    }
}
