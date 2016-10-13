using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class CalendarToRoom
    {
        public int ID { get; set; }
        [Display(Name = "Please Reserve Room on this Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BookRoom { get; set; }

        //one to Many Relationship. As an asscoiate Entitiy between Calendar and Room
        //These two lines represent the many side
        [Display(Name = "Room Number")]
        public int? RoomID { get; set; }
        public virtual Room Room { get; set; }

        //one to Many Relationship. One Booking Can have many dates/Rooms
        //These two lines represent the many side
        [Display(Name = "Booking")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public int? BookingID { get; set; }
        public virtual Booking Booking { get; set; }

        public bool IsBooked { get; set; }
    }
}
