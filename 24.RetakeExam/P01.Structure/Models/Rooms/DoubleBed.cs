using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public class DoubleBed : Room
    {
        private const int BedCapacity = 2;
        public DoubleBed() 
            : base(BedCapacity)
        {
        }
    }
}
