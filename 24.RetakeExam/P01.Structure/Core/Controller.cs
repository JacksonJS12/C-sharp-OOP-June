using BookingApp.Core.Contracts;
using BookingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Utilities.Messages;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;
        private RoomRepository rooms;
        private BookingRepository bookings;
        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = this.hotels.All().FirstOrDefault(x => x.FullName == hotelName);
            string output;
            if (hotel == null)
            {
                this.hotels.AddNew(hotel);
                output = (OutputMessages.HotelSuccessfullyRegistered, category, hotelName).ToString();
            }
            output = (OutputMessages.HotelAlreadyRegistered, hotelName).ToString();
            return output;
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            this.hotels.All().OrderBy(x => x.FullName);
            this.rooms.All().Where(X => X.PricePerNight > 0);
            this.rooms.All().OrderBy(x => x.BedCapacity);
            this.rooms.All().FirstOrDefault(x => x.BedCapacity >= adults + children);

            var output = new StringBuilder();
            var hotel = this.hotels.All().FirstOrDefault(x => x.Category == category);
            if (hotel == null);
            {
                output.AppendLine((OutputMessages.CategoryInvalid, category).ToString());
            }
            if (this.rooms.All().FirstOrDefault(x => x.BedCapacity == adults + children) == null)
            {
                output.AppendLine((OutputMessages.RoomNotAppropriate).ToString());
            }
            var booking = this.bookings.All().FirstOrDefault(x => x.BookingNumber == 1);
            if (booking != null)
            {
                output.AppendLine((OutputMessages.BookingSuccessful, booking.BookingNumber, hotel.FullName).ToString());
               int totalBookingAppBookingsCount = this.bookings.All().Sum(x => x.BookingNumber) + 1;
               IBooking newBokking = new Booking(booking.Room, booking.ResidenceDuration, booking.AdultsCount, booking.ChildrenCount, totalBookingAppBookingsCount + 1);
                this.bookings.AddNew(newBokking);
            }
            return output.ToString().TrimEnd();

        }

        public string HotelReport(string hotelName)
        {
            var sb = new StringBuilder();
            if (this.hotels.All().FirstOrDefault(x => x.FullName == hotelName) != null)
            {
              return (OutputMessages.HotelNameInvalid, hotelName).ToString();
            }
            string output = this.bookings.All().Count > 0 ?
                            string.Join(Environment.NewLine, this.bookings.All().Select(x => x.BookingSummary()))
                            : "none";


        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = this.hotels.All().FirstOrDefault(x => x.FullName == hotelName);
            IRoom room = this.rooms.All().FirstOrDefault(x => x.GetType().Name == roomTypeName);
            var output = new StringBuilder();
            if (hotel == null)
            {
                output.AppendLine((OutputMessages.HotelNameInvalid, hotelName).ToString());
                if (room == null)
                {
                    throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
                }
                else
                {
                    output.AppendLine(OutputMessages.RoomTypeNotCreated);
                    room.SetPrice(price);
                    output.AppendLine((OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName).ToString());
                }
            }
            return output.ToString().TrimEnd();
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = this.hotels.All().FirstOrDefault(x => x.FullName == hotelName);
            IRoom room = this.rooms.All().FirstOrDefault(x => x.GetType().Name == roomTypeName);
            var output = new StringBuilder();
            if (hotel == null)
            {
                output.AppendLine((OutputMessages.HotelNameInvalid, hotelName).ToString());

                if (room != null)
                {
                    output.AppendLine(OutputMessages.RoomTypeAlreadyCreated);
                    IRoom room1;
                    if (roomTypeName == "Apartment")
                    {
                        room1 = new Apartment();
                    }
                    else if (roomTypeName == "DoubleBed")
                    {
                        room1 = new DoubleBed();
                    }
                    else if (roomTypeName == "Studio")
                    {
                        room1 = new Studio();
                    }
                    room1 = null;
                    this.rooms.AddNew(room1);
                    output.AppendLine((OutputMessages.RoomTypeAdded, roomTypeName, hotelName).ToString());
                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
                }
            }

            return output.ToString().TrimEnd();


        }
    }
}
