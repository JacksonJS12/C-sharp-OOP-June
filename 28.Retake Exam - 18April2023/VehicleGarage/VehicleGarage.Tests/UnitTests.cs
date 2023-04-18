using System;
using System.Linq;
using NUnit.Framework;

namespace VehicleGarage.Tests
{
    [TestFixture]
    public class VehicleTests
    {
        [Test]
        public void PropertyInitialize()
        {
            Vehicle vehicle = new Vehicle("Brand", "Model", "0000", 200);
            bool expectedVehicleIsDamaged = false;
            int expectedBatteryLevel = 100;

            Assert.AreEqual("Brand", vehicle.Brand);
            Assert.AreEqual("Model", vehicle.Model);
            Assert.AreEqual("0000", vehicle.LicensePlateNumber);
            Assert.AreEqual(expectedBatteryLevel, vehicle.BatteryLevel);
            Assert.AreEqual(expectedVehicleIsDamaged, vehicle.IsDamaged);


        }

        [Test]
        public void CtorInitialize()
        {
            Vehicle vehicle = new Vehicle("Brand", "Model", "0000", 200);
            Assert.IsNotNull(vehicle);
        }
    }

    [TestFixture]
    public class GarageTests
    {
        [Test]
        public void CtorInitializeCollection()
        {
            Garage garage = new Garage(2);

            Assert.NotNull(garage.Vehicles);
        }

        [Test]
        public void ValidateAddVehicleMethodReturnFalse()
        {
            Garage garage = new Garage(0);
            Vehicle vehicle = new Vehicle("Brand", "Model", "0000", 200);

            Assert.False(garage.AddVehicle(vehicle));
        }
        [Test]
        public void ValidateAddVehicleMethodReturnTrue()
        {
            Garage garage = new Garage(2);
            Vehicle vehicle = new Vehicle("Brand", "Model", "0000", 200);

            Assert.True(garage.AddVehicle(vehicle));
        }

        [Test]
        public void ValidateChargeVehiclesMethod()
        {
            Garage garage = new Garage(2);
            Vehicle vehicle1 = new Vehicle("Brand", "Model", "0000", 200);
            Vehicle vehicle2 = new Vehicle("Brand", "Model", "0000", 200);

            garage.AddVehicle(vehicle1);

            Assert.AreEqual(1, garage.ChargeVehicles(101));
            Assert.AreEqual(0, garage.ChargeVehicles(99));
        }

        [Test]
        public void ValidateDriveVehicleMethod()
        {
            Garage garage = new Garage(2);
            Vehicle vehicle1 = new Vehicle("Brand", "Model", "1111", 111);

            garage.AddVehicle(vehicle1);
            garage.DriveVehicle("1111", 20, true);

            Assert.AreEqual(true, garage.Vehicles.FirstOrDefault(v => v.LicensePlateNumber == "1111").IsDamaged);
            Assert.AreEqual(80, garage.Vehicles.FirstOrDefault(v => v.LicensePlateNumber == "1111").BatteryLevel);
        }
        [Test]
        public void ValidateRepairVehiclesMethod()
        {
            Garage garage = new Garage(2);
            Vehicle vehicle1 = new Vehicle("Brand", "Model", "1111", 111);

            garage.AddVehicle(vehicle1);
            garage.DriveVehicle("1111", 20, true);

            Assert.AreEqual("Vehicles repaired: 1", garage.RepairVehicles());
        }

    }
}