using BookingHotelApp.Data;
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

       // public List<Guests> HotelGuests;
        List<Guests> mGuestList = new List<Guests>();

        public IActionResult HotelBooking()
        {
            mGuestList= getdata();
           
            return View(mGuestList);
        }

        public List<Guests> getdata()
        {
            DateTime?  dt= null;
            ManageBooking m = new ManageBooking();
            mGuestList = m.AddBooking("", 101, Convert.ToDateTime(dt));
            mGuestList = m.AddBooking("", 102, Convert.ToDateTime(dt));
            mGuestList = m.AddBooking("", 201, Convert.ToDateTime(dt));
            mGuestList = m.AddBooking("", 203, Convert.ToDateTime(dt));

            return mGuestList;
        }
        public IEnumerable<int> getAvilableRoom(DateTime date)
        {
            List<int> list = new List<int>();
            var resultdata = HotelData.guestsList;

            if (resultdata != null)
            {
                foreach (var item in resultdata)
                {
                    if (item.BookDate == date)
                    {
                        //find that room and it is notavilable
                   
                    }
                    else
                    {
                        //Add to the int list
                        list.Add(item.RoomNo);

                    }


                }
            }

            return list;

        }

        //Ajax Calls 
        //Adding Data to List for Booking
        [HttpPost]
        public JsonResult AddtoListData([FromBody] Guests guest)
        {
            var resultdata = HotelData.guestsList;
            ManageBooking m = new ManageBooking();
            bool result = false;
            foreach (var item in resultdata)
            {
                if(guest.RoomNo==item.RoomNo)
                {
                    if (item.LastName == guest.LastName || item.BookDate==guest.BookDate)
                    {
                        return (Json(new { resultdata, result }));
                    }
                    else
                    {
                        item.RoomNo = guest.RoomNo;
                        item.LastName = guest.LastName;
                        item.BookDate = guest.BookDate;
                        result = true;
                    }
                }
                


            }

          //  mGuestList = m.AddBooking(guest.LastName, guest.RoomNo, guest.BookDate);
            return Json(new { resultdata, result = true });
            
        }
        //Getting the int List of Room

        [HttpPost]
        public JsonResult GetRooms(DateTime selectdate)
        {
            IEnumerable<int> rooms = new List<int>();
            bool result = false;
            rooms = getAvilableRoom(Convert.ToDateTime(selectdate));
            if(rooms==null)
            {
                return (Json(new { rooms, result }));

            }
            else
            {
                return Json(new { rooms, result = true });
            }
           
        }
       

    
        //public List<Guests> GetGuests()
        //{
        //    return mGuestList;
        //}
    }
}
