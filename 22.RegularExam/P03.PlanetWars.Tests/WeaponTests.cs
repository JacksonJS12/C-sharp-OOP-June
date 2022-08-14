using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class WeaponTests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void NamePropertyShouldSetValue()
            {
                Weapon weapon = new Weapon("Ak-47", 10, 5);
                string expectedName = "Ak-47";

                Assert.AreEqual(expectedName, weapon.Name);
            }

            [Test]
            [TestCase(1)]
            [TestCase(10)]
            [TestCase(999)]
            public void PricePropertyShouldWorkCorrectly(double price)
            {
                Weapon weapon = new Weapon("Ak-47", price, 5);

                Assert.AreEqual(weapon.Price, price);
            }

            [Test]
            [TestCase(-1)]
            [TestCase(-10)]
            [TestCase(-999)]
            public void PricePropertyShouldThrownArgumentException(double price)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("M-48", price, 11);
                },
                "Price cannot be negative."
                );
            }

            [Test]
            public void DestructionLevelPropertyShouldSetValue()
            {
                Weapon weapon = new Weapon("WeaponName", 20, 5);
                int expectedDestructionLevel = 5;

                Assert.AreEqual(expectedDestructionLevel, weapon.DestructionLevel);
            }

            [Test]
            public void IncreaseDestructionLevelMethodShouldAdd1ToDestructionLevel()
            {
                Weapon weapon = new Weapon("WeaponName", 20, 5);
                weapon.IncreaseDestructionLevel();
                int expectedDestructionLevel = 6;

                Assert.AreEqual(expectedDestructionLevel, weapon.DestructionLevel);
            }

            [Test]
            public void IsNuclearPropertyShouldBeTrue()
            {
                Weapon weapon = new Weapon("Name", 35, 12);

                bool isNuclear = weapon.IsNuclear;

                Assert.IsTrue(isNuclear);
            }

            [Test]
            public void IsNuclearPropertyShouldBeFalse()
            {
                Weapon weapon = new Weapon("Name", 45, 2);

                bool isNuclear = weapon.IsNuclear;

                Assert.IsFalse(isNuclear);
            }
        }
    }
}
