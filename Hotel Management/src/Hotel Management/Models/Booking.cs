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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
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

        [Display(Name = "Booking Reference Number")]
        public string BookingRef { get; set; }

        //one to Many Relationship. One Customer can have many Bookings
        //These two lines represent the many side
        [Display(Name = "Guest Name")]
        public int? CustomerGuestID { get; set; }
        public virtual CustomerGuest CustomerGuest { get; set; }

        //one to Many Relationship. One Room Type can be on many Bookings
        //These two lines represent the many side
        [Display(Name = "Room Type")]
        public int? RoomTypeID { get; set; }
        public virtual RoomType RoomType { get; set; }

        //one to Many Relationship. One CreditCard can be used for many Bookings
        //These two lines represent the many side
        [Display(Name = "Credit Card")]
        public int? CreditCardDetailsID { get; set; }
        public virtual CreditCardDetails CreditCardDetails { get; set; }

        //one to Many Relationship. One Invoice can have many Bookings
        //These two lines represent the many side
        [Display(Name = "Invoice")]
        public int? InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }

        //one to Many Relationship. One Room can have many Dates
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<CalendarToRoom> CalendarToRoom { get; set; }

        //one to Many Relationship. One Status can be on many Bookings
        //These two lines represent the many side
        [Display(Name = "Checked In Status")]
        public int? CheckInStatusID { get; set; }
        public virtual CheckInStatus CheckInStatus { get; set; }

        //one to Many Relationship. One Booking Method can be on many bookings
        //These two lines represent the many side
        [Display(Name = "Booking Method")]
        public int? HowBookedID { get; set; }
        public virtual HowBooked HowBooked { get; set; }


    }
}
