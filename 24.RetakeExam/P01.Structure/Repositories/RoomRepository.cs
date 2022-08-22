using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private readonly ICollection<IRoom> all;
        public RoomRepository()
        {
            this.all = new List<IRoom>();
        }
        public void AddNew(IRoom model)
            => this.all.Add(model);

        public IReadOnlyCollection<IRoom> All()
          => (IReadOnlyCollection<IRoom>)this.all;

        public IRoom Select(string criteria)
        {
            IRoom room;
            if (criteria == "Apartment")
            {
                room = new Apartment();
            }
            else if (criteria == "DoubleBed")
            {
                room = new DoubleBed();
            }
            else if (criteria == "Studio")
            {
                room = new Studio();
            }
            room = null;
            return room;
        }
    }
}
