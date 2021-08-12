using BookingHotelApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelApp.Controllers
{
    public class BookingManager : Controller
    {
        public Guests _Guest;

        public List<Guests> HotelGuests;
        List<Guests> mGuestList = new List<Guests>();

        public IActionResult HotelBooking()
        {
            ManageBooking m = new ManageBooking();
            //mGuestList = m.AddBooking("",101,DateTime.Today);
            //mGuestList = m.AddBooking("", 102, DateTime.Today);
            //mGuestList = m.AddBooking("", 201, DateTime.Today);
            //mGuestList = m.AddBooking("", 203, DateTime.Today);

            return View(mGuestList);
        }

        //Adding Data to List for Booking
        [HttpPost]
        public JsonResult AddtoListData([FromBody] Guests guest)
        {
            ManageBooking m = new ManageBooking();
            bool result = false;
            foreach (var item in mGuestList)
            {
                if (item.RoomNo == guest.RoomNo && item.LastName == guest.LastName)
                {
                    return (Json(new { result }));
                }
                else
                {
                    item.RoomNo = guest.RoomNo;
                    item.LastName = guest.LastName;
                    item.BookDate = guest.BookDate;
                    result = true;
                }


            }

            mGuestList = m.AddBooking(guest.LastName, guest.RoomNo, guest.BookDate);
            return Json(new { mGuestList, result = true });
            
        }

        //public List<Guests> GetGuests()
        //{
        //    return mGuestList;
        //}
    }
}
