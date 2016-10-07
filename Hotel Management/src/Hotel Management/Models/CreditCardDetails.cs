using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    public class CreditCardDetails
    {
        public int ID { get; set; }
        public string CreditCardNumber { get; set; }
        public int CreditCardExpiryMonth { get; set; }
        public int CreditCardExpiryYear { get; set; }
        public int CreditCardCVC { get; set; }
        public string CreditCardName { get; set; }
        public string CreditCardNotes { get; set; }

        //one to Many Relationship. One CreditCard can have many Bookings
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Booking> Booking { get; set; }

        //one to Many Relationship. One CreditCard can have many Payments
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
