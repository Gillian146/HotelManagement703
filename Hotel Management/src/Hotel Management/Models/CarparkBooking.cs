using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class CarparkBooking
    {
        public int ID { get; set; }

        [Display(Name = "Date Carpark is Booked")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        //one to Many Relationship. One CarPark can have many CarparkBookings
        //These two lines represent the many side
        [Display(Name = "Carpark")]
        public int? CarparkID { get; set; }
        public virtual Carpark Carpark { get; set; }

        //one to Many Relationship. One Customer can have many CarparkBookings
        //These two lines represent the many side
        [Display(Name = "Guest")]
        public int? CustomerGuestID { get; set; }
        public virtual CustomerGuest CustomerGuest { get; set; }
    }
}
