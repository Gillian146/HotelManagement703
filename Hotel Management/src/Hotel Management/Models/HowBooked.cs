using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;


namespace Hotel_Management.Models
{
    public class HowBooked
    {
        public int ID { get; set; }

        [Display(Name = "Booking Info")]
        public int BookingMedium { get; set; }

        //one to Many Relationship. One Booking Method can be on many bookings
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
