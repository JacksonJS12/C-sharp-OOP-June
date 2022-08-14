using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            [TestCase("Earth")]
            [TestCase("earth2")]
            [TestCase("Venus")]
            public void NamePropertyShouldSetValueCorrectly(string name)
            {
                Planet planet = new Planet(name, 100);

                Assert.AreEqual(name, planet.Name);
            }

            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void NamePropertyShouldThrownArgumentException(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(name, 100);
                }, "Invalid planet Name");
            }

            [Test]
            [TestCase(1)]
            [TestCase(10)]
            [TestCase(100)]
            public void BudgetPropertyShouldSetValueCorrectly(double budget)
            {
                Planet planet = new Planet("Earth", budget);

                Assert.AreEqual(budget, planet.Budget);
            }
            [Test]
            [TestCase(-1)]
            [TestCase(-10)]
            [TestCase(-999)]
            public void BudgetPropertyShouldThrownArgumentException(double budget)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("Earth", budget);
                }, "Budget cannot drop below Zero!");
            }

            [Test]
            public void AddWeaponMethodShouldWork()
            {
                Planet planet = new Planet("Earth", 100);
                Weapon weapon = new Weapon("AK-47", 75, 5);

                planet.AddWeapon(weapon);
                int expectedCount = 1;
                int actualCount = planet.Weapons.Count;

                Assert.AreEqual(expectedCount, actualCount);
            }

            [Test]
            public void AddWeaponMethodShouldThrownInvalidOperationException()
            {
                Planet planet = new Planet("Earth", 100);
                Weapon weapon1 = new Weapon("AK-47", 75, 5);
                Weapon weapon2 = new Weapon("WeaponName", 2, 3);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon2);
                }, $"There is already a {weapon2.Name} weapon.");
            }

            [Test]
            public void MilitaryPowerRatioPropertyShouldWork()
            {
                Planet planet = new Planet("Earth", 100);
                Weapon weapon1 = new Weapon("AK-47", 75, 5);
                Weapon weapon2 = new Weapon("WeaponName", 2, 3);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                double actualMilitaryPowerRatio = planet.MilitaryPowerRatio;
                double expectedMilitaryPowerRatio = 8;

                Assert.AreEqual(expectedMilitaryPowerRatio, actualMilitaryPowerRatio);
            }

            [Test]
            [TestCase(100)]
            [TestCase(25)]
            [TestCase(2)]
            public void ProfitMethodShouldWork(double amount)
            {
                Planet planet = new Planet("Earth", 100);

                planet.Profit(amount);

                double expected = 100 + amount;
                double actual = planet.Budget;

                Assert.AreEqual(expected, actual);
            }
            
            [Test]
            [TestCase(99)]
            [TestCase(25)]
            [TestCase(2)]
            public void SpendFundsMethodShouldWork(double amount)
            {
                Planet planet = new Planet("Earth", 100);

                planet.SpendFunds(amount);

                double expected = 100 - amount;
                double actual = planet.Budget;

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void SpendFundsMethodShouldThrownInvalidOperationException()
            {
                Planet planet = new Planet("Earth", 100);
                double amount = 110;

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(amount);
                }, $"Not enough funds to finalize the deal."
                );
            }


            [Test]
            public void RemoveWeaponShouldWork()
            {
                Planet planet = new Planet("Earth", 100); 
                Weapon weapon1 = new Weapon("AK-47", 75, 5);
                Weapon weapon2 = new Weapon("WeaponName", 2, 3);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.RemoveWeapon(weapon1.Name);

                int expectedCount = 1;
                int actualCount = planet.Weapons.Count;
                Assert.AreEqual(expectedCount, actualCount);

            }


            [Test]
            [TestCase("AK-47")]
            public void UpgradeWeaponShouldWork(string weaponName)
            {
                Planet planet = new Planet("Earth", 100);
                Weapon weapon1 = new Weapon("AK-47", 75, 5);
                Weapon weapon2 = new Weapon("WeaponName", 2, 3);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.UpgradeWeapon(weaponName);

                int expected = 6;
                int actual = weapon1.DestructionLevel++;

                Assert.AreEqual(expected, actual);
            }

            [Test]
            [TestCase("Name")]
            [TestCase("Weapon")]
            public void UpgradeWeaponShouldThrownInvalidOperationException(string weaponName)
            {
                Planet planet = new Planet("Earth", 100);
                Weapon weapon1 = new Weapon("AK-47", 75, 5);
                Weapon weapon2 = new Weapon("WeaponName", 2, 3);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon(weaponName);
                }, 
                $"{weaponName} does not exist in the weapon repository of {planet}"
                );
            }

            [Test]
            public void DestructOpponentShouldWork()
            {
                Planet planet1 = new Planet("Earth", 100);
                Planet planet2 = new Planet("Venus", 200);

                Weapon weapon1 = new Weapon("AK-47", 75, 5);
                Weapon weapon2 = new Weapon("WeaponName", 2, 3);

                planet1.AddWeapon(weapon1);
                planet2.AddWeapon(weapon2);

                string expected = $"{planet2.Name} is destructed!";
                string actual = planet1.DestructOpponent(planet2);

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void DestructOpponentShouldThrownInvalidOperationException()
            {
                Planet planet1 = new Planet("Earth", 100);
                Planet planet2 = new Planet("Venus", 200);

                Weapon weapon1 = new Weapon("AK-47", 75, 5);
                Weapon weapon2 = new Weapon("WeaponName", 2, 10);

                planet1.AddWeapon(weapon1);
                planet2.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet1.DestructOpponent(planet2);
                },
                $"{planet2.Name} is too strong to declare war to!"
                );
            }
        }
    }
}
