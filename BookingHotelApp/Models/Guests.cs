using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookingHotelApp.Models
{
    public class Guests
    {
        [Key]
        public string LastName { get; set; }
        [Key]
        public int RoomNo { get; set; }

        public DateTime BookDate { get; set; }
        //List<Guests> _guest = new List<Guests>();

    }
}