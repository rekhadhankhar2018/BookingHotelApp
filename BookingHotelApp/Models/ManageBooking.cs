using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelApp.Models
{
    public class ManageBooking : IManageBooking
    {
        public Guests _Guest;

        public List<Guests> HotelGuests; 
        List<Guests> mGuestList = new List<Guests>();
        public ManageBooking()
        {
            ////create the 4 rooms here
            //_Guest = new Guests()
            //{

            //};
            HotelGuests = GetGuests();
        }
        public bool IsRoomAvailable(int Room, DateTime date)
        {
            //Check for room avilablity
            return true;
        }
        public List<Guests> AddBooking(string guest, int room, DateTime date)
        {
           
            Guests g = new Guests() { RoomNo = room, LastName = guest, BookDate = date };
            mGuestList.Add(g);
            return mGuestList;
        }

        //test
        public List<Guests> GetGuests()
        {            
            
            return mGuestList;
        }

        //romm avilablity check
    }
}
