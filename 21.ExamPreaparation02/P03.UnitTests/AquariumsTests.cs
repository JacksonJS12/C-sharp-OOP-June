namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class AquariumsTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void AquariumNamePropertyShouldThrowArgumentNullException(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Arrange & Act
                var aquarium = new Aquarium(name, 10);
            },
            //Assert
            "Invalid aquarium name!");
        }

        [Test]
        public void AquariumNamePropertyShouldWorkProperty()
        {
            //Arrange
            const string expectedName = "Test";

            //Act
            Aquarium aquarium = new Aquarium("Test", 10);

            //Assert
            Assert.AreEqual(expectedName, aquarium.Name);
        }

        [TestCase(-1000)]
        [TestCase(-1)]
        public void AquariumCapacityPropertyShouldThrowArgumentException(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange & Act
                var aquarium = new Aquarium("Test", capacity);
            },
            //Assert
            "Invalid aquarium capacity!");
        }

        [Test]
        public void AquariumCapacityPropertyShouldWorkCorrectly()
        {
            //Arrange
            const int expectedCapacity = 15;

            //Act
            Aquarium aquarium = new Aquarium("Test", 15);

            //Assert
            Assert.AreEqual(expectedCapacity, aquarium.Capacity);
        }

        [Test]
        public void AquariumAddMethodShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {   
                //Arrange & Act
                Aquarium aquarium = new Aquarium("Test", 1);

                var firstFish = new Fish("TestFish");
                var secondFish = new Fish("TestFish2");

                aquarium.Add(firstFish);

                aquarium.Add(secondFish);
            },
            //Assert
            "Aquarium is full!");
        }
        [Test]
        public void AquariumAddMethodShouldAddFishToTheAquarium()
        {
            //Arrange 
            Aquarium aquarium = new Aquarium("Test", 2);

            var firstFish = new Fish("TestFish");

            //Act
            aquarium.Add(firstFish);

            //Assert
            Assert.AreEqual(1, aquarium.Count);

        }
        [TestCase(null)]
        public void AquariumRemoveFishMethodShouldTrownInvalidOperationException(string name)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {   //Arrange & Act
                Aquarium aquarium = new Aquarium("Tank1", 2);
                aquarium.RemoveFish(name);
            },
            //Assert
            $"Fish with the name {name} doesn't exist!");
        }

        [Test]
        public void AquariumRemoveFishMethodShouldRemoveFishFromTheAquarium()
        {
            //Arrange 
            Aquarium aquarium = new Aquarium("Test123", 2);

            var firstFish = new Fish("TestFish");
            var secondFish = new Fish("Fish");

            //Act
            aquarium.Add(firstFish);
            aquarium.Add(secondFish);

            aquarium.RemoveFish(secondFish.Name);

            //Assert
            Assert.That(aquarium.Count, Is.EqualTo(1));

        }

        [TestCase(null)]
        public void AquariumSellFishMethodShouldTrownInvalidOperationException(string name)
        {
            Assert.Throws<InvalidOperationException>(() =>
            { 
                //Arrange & Act
                Aquarium aquarium = new Aquarium("Tank1", 2);
                var firstFish = new Fish("Fish1");

                aquarium.Add(firstFish);

                aquarium.SellFish(name);
            },
            //Assert
            $"Fish with the name {name} doesn't exist!");
        }

        [Test]
        public void AquariumSellFishMethodShouldSellFishFromTheAquarium()
        {
            //Arrange 
            Aquarium aquarium = new Aquarium("Test", 2);

            var firstFish = new Fish("TestFish");
            var secondFish = new Fish("Fish");

            //Act
            aquarium.Add(secondFish);
            aquarium.Add(firstFish);

            aquarium.SellFish(secondFish.Name);

            //Assert
            Assert.AreEqual("Fish", secondFish.Name);

        }

        [Test]
        public void AquariumReportShouldReturnCorrectFormattedReport()
        {
            //Arrange
            Aquarium aquarium = new Aquarium("FishTank", 4);

            var firstFish = new Fish("PurpleFish");
            var secondFish = new Fish("GreenFish");
            var thirthFish = new Fish("RegularFish");

            string expectedReport = "Fish available at FishTank: PurpleFish, RegularFish, GreenFish";

            //Act
            aquarium.Add(firstFish);
            aquarium.Add(thirthFish);
            aquarium.Add(secondFish);

            //Assert
            Assert.AreEqual(expectedReport, aquarium.Report());
        }


    }
}
