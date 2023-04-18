using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private string licensePlateNumber;

        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            this.Brand = brand;
            this.Model = model;
            this.MaxMileage = maxMileage;
            this.LicensePlateNumber = licensePlateNumber;

            this.BatteryLevel = 100;
        }
        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }
                this.brand = value;
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                this.model = value;
            }
        }
        public double MaxMileage { get; private set; }
        public string LicensePlateNumber
        {
            get
            {
                return this.licensePlateNumber;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                this.licensePlateNumber = value;
            }
        }
        public int BatteryLevel { get; private set; }
        public bool IsDamaged { get; private set; }
        public void Drive(double mileage)
        {
            var percentage = (mileage / MaxMileage) * 100;

            this.BatteryLevel -= (int)Math.Round(percentage);

            if (this.Model== "CargoVan")
            {
                percentage = this.BatteryLevel - (this.BatteryLevel * 0.05);
            }
        }

        public void Recharge()
        {
            this.BatteryLevel = 100;
        }

        public void ChangeStatus()
        {
            if (this.IsDamaged == false)
            {
                this.IsDamaged = true;
                return;
            }
            else if (this.IsDamaged == true)
            {
                this.IsDamaged = false;
                return;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string isOkOrDamage = this.IsDamaged ? "OK" : "damage";
            sb.AppendLine(
                $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {isOkOrDamage}");
            return base.ToString();
        }
    }
}
