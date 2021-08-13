using System;
using System.Collections.Generic;

namespace BookingHotelApp.Models
{
    public interface IManageBooking
    {
        List<Guests> AddBooking(string guest, int room, DateTime date);
        bool IsRoomAvailable(int Room, DateTime date);
        //List<Guests> GetGuests();
    }
}