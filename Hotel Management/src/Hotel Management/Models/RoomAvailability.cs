using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    public class RoomAvailability
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }

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
