using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class Payment
    {
        public int ID { get; set; }

        [Display(Name = "Receipt Number")]
        public int ReceiptNumber { get; set; }

        [Display(Name = "Payment Total")]
        public double TotalPaid { get; set; }

        [Display(Name = "Date of Payment")]
        public DateTime DatePaid { get; set; }

        //one to Many Relationship. One Invoice can have many Payments
        //These two lines represent the many side
        [Display(Name = "Invoice")]
        public int? InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }

        //one to Many Relationship. One CreditCard can have many Payments
        //These two lines represent the many side
        [Display(Name = "Credit Card")]
        public int? CreditCardDetailsID { get; set; }
        public virtual CreditCardDetails CreditCardDetails { get; set; }
    }
}
