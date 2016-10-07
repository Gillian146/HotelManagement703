using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    public class ChargeBack
    {
        public int ID { get; set; }
        public string ChargeBackLocation { get; set; }
        public double ChargeBackTotal { get; set; }

        //one to Many Relationship. One Invoice can have many ChargeBacks
        //These two lines represent the many side
        public int? InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }

        //one to Many Relationship. One Customer can have many ChargeBacks
        //These two lines represent the many side
        public int? CustomerGuestID { get; set; }
        public virtual CustomerGuest CustomerGuest { get; set; }
    }
}
