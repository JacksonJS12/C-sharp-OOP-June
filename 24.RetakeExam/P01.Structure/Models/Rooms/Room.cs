using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private double pricePerNight;
        public int BedCapacity { get; private set; }

        protected Room(int bedCapacity)
        {
            this.BedCapacity = bedCapacity;
        }

        public double PricePerNight 
        {
            get
            {
                return this.pricePerNight;
            }
            set
            {
                if (value < 0)
                {
                    this.pricePerNight = 0;
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }
                this.pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            this.PricePerNight = price;
        }
    }
}
