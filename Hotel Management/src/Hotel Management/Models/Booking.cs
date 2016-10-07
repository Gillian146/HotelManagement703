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

            //still need relationship with Carpark???

        //one to Many Relationship. One Customer can have many Bookings
        //These two lines represent the many side
        public int? CustomerGuestID { get; set; }
        public virtual CustomerGuest CustomerGuest { get; set; }

        //one to Many Relationship. One CreditCard can be used for many Bookings
        //These two lines represent the many side
        public int? CreditCardDetailsID { get; set; }
        public virtual CreditCardDetails CreditCardDetails { get; set; }

        //one to Many Relationship. One Invoice can have many Bookings
        //These two lines represent the many side
        public int? InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }

        //one to Many Relationship. One Room can have many Bookings
        //These two lines represent the many side
        public int? RoomID { get; set; }
        public virtual Room Room { get; set; }

    }
}
