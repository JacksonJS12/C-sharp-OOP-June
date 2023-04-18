using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private string drivingLicenseNumber;


        public User(string firstName, string lastName, string drivingLicenceNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DrivingLicenseNumber = drivingLicenceNumber;
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FirstNameNull);
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LastNameNull);
                }
                this.lastName = value;
            }
        }
        public string DrivingLicenseNumber
        {
            get
            {
                return this.drivingLicenseNumber;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
                }
                this.drivingLicenseNumber = value;
            }
        }
        public double Rating { get; private set; }
        public bool IsBlocked { get; set; }
        public void IncreaseRating()
        {
            this.Rating += 0.5;
            if (this.Rating >= 10.0)
            {
                this.Rating = 10.0;
            }
        }

        public void DecreaseRating()
        {
            this.Rating -= 2.0;
            if (this.Rating <= 0)
            {
                this.Rating = 0.0;
                this.IsBlocked = true;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.FirstName} {this.LastName} Driving license: {this.DrivingLicenseNumber} Rating: {this.Rating}");

            return sb.ToString().TrimEnd();
        }
    }
}
