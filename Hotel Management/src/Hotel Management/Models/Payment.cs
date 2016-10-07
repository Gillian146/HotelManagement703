using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public int ReceiptNumber { get; set; }
        public double TotalPaid { get; set; }
        public DateTime DatePaid { get; set; }

        //one to Many Relationship. One Invoice can have many Payments
        //These two lines represent the many side
        public int? InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }

        //one to Many Relationship. One CreditCard can have many Payments
        //These two lines represent the many side
        public int? CreditCardDetailsID { get; set; }
        public virtual CreditCardDetails CreditCardDetails { get; set; }
    }
}
