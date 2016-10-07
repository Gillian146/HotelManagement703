using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    public class CarParkAvailability
    {
        public int ID { get; set; }
        public DateTime DateBookingMade { get; set; }

        //one to Many Relationship. One Carpark can have many Avalabilites on different Days (this might not work??)
        //These two lines represent the many side
        public int? CarparkID { get; set; }
        public virtual Carpark Carpark { get; set; }

        //one to Many Relationship. One Avaiability can appear on many Associate entitiy (this might not work??)
        //These two lines represent the many side
        public int? AvailabilityID { get; set; }
        public virtual Availability Availability { get; set; }
    }
}
