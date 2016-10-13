using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class Booking
    {
        public int ID { get; set; }

        [Display(Name = "Date Booking Made")]
        [DisplayFormat( DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BookingMade { get; set; }

        [Display(Name = "Date of Arrival")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ArrivalDate { get; set; }

        [Display(Name = "Date of Departure")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DepartureDate { get; set; }


        [Display(Name = "Number of Nights")]      
        public int NumberofNights { get; set; }

        [Display(Name = "In and Out")]
        public string BookingRange { get; set; }

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

        //one to Many Relationship. One Room can have many Dates
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<CalendarToRoom> CalendarToRoom { get; set; }

        //one to Many Relationship. One Status can be on many Bookings
        //These two lines represent the many side
        public int? CheckInStatusID { get; set; }
        public virtual CheckInStatus CheckInStatus { get; set; }


    }
}
