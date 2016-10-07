using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    public class Room
    {
        public int ID { get; set; }
        public int RoomNumber { get; set; }
        public string RoomName { get; set; }
        public double RoomRate { get; set; }

        //one to Many Relationship. One Floor has many Rooms
        //These two lines represent the many side
        public int? FloorID { get; set; }
        public virtual Floor Floor { get; set; }

        //one to Many Relationship. One Room can have many Avaailabilites
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<RoomAvailability> RoomAvailability { get; set; }

        //one to Many Relationship. One Room can have many Bookings
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
