using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    public class Booking
    {
        public int ID { get; set; }

        public DateTime BookingMade { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }

        //Number of Mights is computed

        //one to Many Relationship. One Customer can have many Bookings
        //These two lines represent the many side
        public int? CustomerGuestID { get; set; }
        public virtual CustomerGuest CustomerGuest { get; set; }


    }
}
