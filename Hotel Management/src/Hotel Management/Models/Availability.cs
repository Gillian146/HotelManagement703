using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class Availability
    {
        public int ID { get; set; }

        [Display(Name = "Availability Status")]
        public String AvailabilityStatus { get; set; }

        //one to Many Relationship. One  Availabilities on many Carparks on different dates - uses asscoiative
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<CarParkAvailability> CarParkAvailability { get; set; }

        //one to Many Relationship. One Availbilites has many Room AvaialabilityDates
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<RoomAvailability> RoomAvailability { get; set; }
    }
}
