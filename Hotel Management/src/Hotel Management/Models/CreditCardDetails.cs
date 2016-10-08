using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class CreditCardDetails
    {
        public int ID { get; set; }

        [Display(Name = "Credit Card Number")]
        public string CreditCardNumber { get; set; }

        [Display(Name = "Credit Card Expiry Month")]
        public int CreditCardExpiryMonth { get; set; }

        [Display(Name = "Credit Card Expiry Year")]
        public int CreditCardExpiryYear { get; set; }

        [Display(Name = "Credit Card CVC ")]
        public int CreditCardCVC { get; set; }

        [Display(Name = "Name on Card")]
        public string CreditCardName { get; set; }

        [Display(Name = "Credit Card Notes")]
        public string CreditCardNotes { get; set; }

        //one to Many Relationship. One CreditCard can have many Bookings
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Booking> Booking { get; set; }

        //one to Many Relationship. One CreditCard can have many Payments
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
