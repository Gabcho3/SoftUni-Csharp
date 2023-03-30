using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories.Classes
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;

        public BookingRepository()
        {
            this.bookings = new List<IBooking>();
        }

        public void AddNew(IBooking model)
        {
            bookings.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return bookings;
        }

        public IBooking Select(string bookingNumberToString)
        {
            return bookings.FirstOrDefault(b => b.BookingNumber.ToString() == bookingNumberToString);
        }
    }
}
