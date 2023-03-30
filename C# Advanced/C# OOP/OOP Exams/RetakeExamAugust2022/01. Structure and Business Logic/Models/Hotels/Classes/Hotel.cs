using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Linq;

namespace BookingApp.Models.Hotels.Classes
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;



        public string FullName
        {
            get { return fullName; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }
                fullName = value;
            }
        }

        public int Category
        {
            get { return category; }
            private set
            {
                if(value < 0 && value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }
                category = value;
            }
        }

        public double Turnover => Bookings.All().Select(b => b.ResidenceDuration * b.Room.PricePerNight).Sum();

        public IRepository<IRoom> Rooms => throw new NotImplementedException();

        public IRepository<IBooking> Bookings => throw new NotImplementedException();
    }
}
