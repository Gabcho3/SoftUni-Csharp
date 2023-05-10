using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings.Classes;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Classes;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Classes;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;
        private List<string> roomTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && t.Namespace == "BookingApp.Models.Rooms.Classes")
                .Select(t => t.Name).ToList();

        public Controller()
        {
            this.hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (hotels.All().Any(h => h.FullName == hotelName))
            {
                return $"Hotel {hotelName} is already registered in our platform.";
            }

            IHotel hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);
            return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            int totalPeople = adults + children;
            List<IHotel> availableHotels = hotels.All().Where(h => h.Category == category).OrderBy(h => h.FullName).ToList();

            if (availableHotels == null)
            {
                return $"{category} star hotel is not available in our platform.";
            }

            return null;
            //I cannot create the logic!

            //if (room == null)
            //{
            //    return "We cannot offer appropriate room for your request.";
            //}

            //IHotel hotel = hotels.All().FirstOrDefault(h => h.Rooms.All().Contains(room));
            //IBooking booking = new Booking(room, duration, adults, children, hotels.All().Select(h => h.Bookings).Count() + 1);
            //hotel.Bookings.AddNew(booking);
            //return $"Booking number {booking.BookingNumber} for {hotel.FullName} hotel is successful!";
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.All().FirstOrDefault(h => h.FullName == hotelName);
            if (hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:f2} $");
            sb.AppendLine("-- Bookings:");

            foreach(var booking in hotel.Bookings.All())
            {
                sb.AppendLine();
                sb.AppendLine(booking.ToString());
            }

            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine("none");
            }

            return sb.ToString().Trim();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            if (!roomTypes.Contains(roomTypeName))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            if (!hotel.Rooms.All().Any(r => r.GetType().Name.Contains(roomTypeName)))
            {
                return "Room type is not created yet!";
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (room.PricePerNight > 0) //price have already set once
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

            room.SetPrice(price);
            return $"Price of {roomTypeName} room type in {hotelName} hotel is set!";
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            if (hotel.Rooms.GetType().Name.Contains(roomTypeName))
            {
                return "Room type is already created!";
            }

            if (!roomTypes.Contains(roomTypeName))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == roomTypeName);
            IRoom room = Activator.CreateInstance(type) as IRoom;
            hotel.Rooms.AddNew(room);
            return $"Successfully added {roomTypeName} room type in {hotelName} hotel!";
        }
    }
}
