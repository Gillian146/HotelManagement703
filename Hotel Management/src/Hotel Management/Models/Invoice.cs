using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class Invoice
    {
        public int ID { get; set; }

        [Display(Name = "Total Due For Payment")]
        public double TotalDue { get; set; }

        [Display(Name = "GST % Rate")]
        public double GSTRate { get; set; }

        [Display(Name = "Date Invoice Prepared")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DatePrepared { get; set; }

        [Display(Name = "GST Included")]
        public double GST { get; set; }

        //one to Many Relationship. One Invoice can have many Payments
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Payment> Payment { get; set; }

        //one to Many Relationship. One Invoice can have many Bookings
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Booking> Booking { get; set; }

        //one to Many Relationship. One Invoice can have many ChargeBacks
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<ChargeBack> ChargeBack { get; set; }
    }
}
