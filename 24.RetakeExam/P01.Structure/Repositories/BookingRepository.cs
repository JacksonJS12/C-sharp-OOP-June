using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private readonly ICollection<IBooking> all;
        public BookingRepository()
        {
            this.all = new List<IBooking>();
        }
        public void AddNew(IBooking model)
          => this.all.Add(model);

        public IReadOnlyCollection<IBooking> All()
        => (IReadOnlyCollection<IBooking>)this.all;

        public IBooking Select(string criteria)
           => this.all.FirstOrDefault(x => x.BookingNumber.ToString() == criteria);
    }
}
