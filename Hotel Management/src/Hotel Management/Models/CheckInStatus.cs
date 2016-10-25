using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;


namespace Hotel_Management.Models
{
    public class CheckInStatus
    {
        public int ID { get; set; }

        [Display(Name = "Guest at Reception")]
        public string  GuestStatusatReception { get; set; }

        [Display(Name = "Guest Status in Room")]
        public string GuestStatusinRoom { get; set; }


        //one to Many Relationship. One Status can be on many Bookings
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
