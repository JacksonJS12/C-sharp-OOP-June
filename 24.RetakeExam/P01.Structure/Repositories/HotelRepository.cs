using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private readonly ICollection<IHotel> all;
        public HotelRepository()
        {
            this.all = new List<IHotel>();
        }
        public void AddNew(IHotel model)
         => this.all.Add(model);

        public IReadOnlyCollection<IHotel> All()
             => (IReadOnlyCollection<IHotel>)this.all;

        public IHotel Select(string criteria)
            => this.all.FirstOrDefault(x => x.FullName == criteria);
    }
}
