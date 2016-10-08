using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class RoomAvailability
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }

        //one to Many Relationship. One Room has many Availbilites
        //These two lines represent the many side
        public int? RoomID { get; set; }
        public virtual Room Room { get; set; }

        //one to Many Relationship. One Availbilites has many Room AvaialabilityDates
        //These two lines represent the many side
        public int? AvailabilityID { get; set; }
        public virtual Availability Availability { get; set; }
    }
}
