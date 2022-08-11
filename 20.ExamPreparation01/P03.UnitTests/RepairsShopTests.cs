using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [TestCase(null)]
            [TestCase("")]
            public void GarageNameShouldThrowExceptionWithEmptyAndNullValues(string test)
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    //Arrange & Act
                    var garage = new Garage(test, 10);
                },
                //Assert
                "Invalid garage name.");
            }

            [Test]
            public void GarageNameShouldWorkCorrectly()
            {
                //Arrange & Act
               const string garageName = "Test";

                var garage = new Garage("Test", 10);

                //Assert
                Assert.That(garage.Name, Is.EqualTo(garageName));
            }

            [TestCase(0)]
            [TestCase(-1)]
            public void GarageMechanicsShouldThrowExceptionWithNoMechanics(int number)
            { 
                Assert.Throws<ArgumentException>(() =>
                {
                    //Arrange & Act
                    var garage = new Garage("Test", number);
                },
                //Assert
               "At least one mechanic must work in the garage."
                );
            }

            [Test]
            public void GarageMechanicsShouldWorkCorrectly()
            {
                //Arrange
                const int garageMechanics = 10;

                //Act
                var garage = new Garage("Test", 10);

                //Assert
                Assert.That(garage.MechanicsAvailable, Is.EqualTo(garageMechanics));
            }

            [Test]
            public void GarageAddCarShouldThrowExceptionWithNoAvaibleMechanics()
            {
                //Arrange
                var garage = new Garage("Test", 1);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car("Mercedes", 15);

                //Act
                garage.AddCar(firstCar);

                //Assert
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(secondCar);
                },
                "No mechanic available."
                );
            }

            [Test]
            public void GarageAddCarShouldIncrementCarCorrectly()
            {
                //Arrange
                var garage = new Garage("Test", 2);
                var firstCar = new Car("Mercedes", 10);
                var secondCar = new Car("Mercedes", 15);

                //Act
                garage.AddCar(firstCar);
                garage.AddCar(secondCar);

                //Assert
                Assert.That(garage.CarsInGarage, Is.EqualTo(2));
            }

        }
    }
}