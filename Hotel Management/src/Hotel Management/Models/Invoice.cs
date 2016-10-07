using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    public class Invoice
    {
        public int ID { get; set; }
        public double TotalDue { get; set; }
        public double GSTRate { get; set; }
        public DateTime DatePrepared { get; set; }
        /// GST will be calculated

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
