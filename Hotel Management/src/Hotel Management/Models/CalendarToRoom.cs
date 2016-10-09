using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    public class CalendarToRoom
    {
        public int ID { get; set; }

        //one to Many Relationship. As an asscoiate Entitiy between Calendar and Room
        //These two lines represent the many side
        public int? RoomID { get; set; }
        public virtual Room Room { get; set; }

        //one to Many Relationship. As an asscoiate Entitiy between Calendar and Room
        //These two lines represent the many side
        public int? CalendarID { get; set; }
        public virtual Calendar Calendar { get; set; }

        //one to Many Relationship. One Booking Can have many dates/Rooms
        //These two lines represent the many side
        public int? BookingID { get; set; }
        public virtual Booking Booking { get; set; }

        public bool IsBooked { get; set; }
    }
}
