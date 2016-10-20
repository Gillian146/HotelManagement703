using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class Room
    {
        public int ID { get; set; }

        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }

        [Display(Name = "Room Name")]
        public string RoomName { get; set; }

        [Display(Name = "Room Rate")]
        public double RoomRate { get; set; }

        //one to Many Relationship. One Floor has many Rooms
        //These two lines represent the many side
        public int? FloorID { get; set; }
        public virtual Floor Floor { get; set; }

        //one to Many Relationship. One RoomType has many Rooms
        //These two lines represent the many side
        public int? RoomTypeID { get; set; }
        public virtual RoomType RoomType { get; set; }

        //one to Many Relationship. One Room can have many Avaailabilites
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<RoomAvailability> RoomAvailability { get; set; }

        //one to Many Relationship. One Room can have many Dates
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<CalendarToRoom> CalendarToRoom { get; set; }

        //one to Many Relationship. One Room can have  many Maintenance Requests
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Maintenance> Maintenance { get; set; }
    }
}
