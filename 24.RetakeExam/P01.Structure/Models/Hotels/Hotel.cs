﻿using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Hotels
{
    internal class Hotel : IHotel
    {
        public string FullName => throw new NotImplementedException();

        public int Category => throw new NotImplementedException();

        public double Turnover => throw new NotImplementedException();

        public IRepository<IRoom> Rooms { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRepository<IBooking> Bookings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
