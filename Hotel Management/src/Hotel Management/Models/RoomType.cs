using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class RoomType
    {
        public int ID { get; set; }

        [Display(Name = "Room Type")]
        public string  RoomTypeName { get; set; }

        [Display(Name = "Room Type Notes")]
        public string RoomTypeNotes { get; set; }

        //one to Many Relationship. One Floor can have many RoomTypes
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Room> Room { get; set; }

        //one to Many Relationship. One Room Type can be on many Bookings
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Booking> Booking { get; set; }

        //one to Many Relationship. One RoomType can have many Beds
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<BedToRoom> BedToRoom { get; set; }
    }
}
