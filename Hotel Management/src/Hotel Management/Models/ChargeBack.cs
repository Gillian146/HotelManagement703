using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class ChargeBack
    {
        public int ID { get; set; }

        [Display(Name = "Charge Back Location")]
        public string ChargeBackLocation { get; set; }


        [Display(Name = "Charge Back Total")]
        public double ChargeBackTotal { get; set; }

        //one to Many Relationship. One Invoice can have many ChargeBacks
        //These two lines represent the many side
        [Display(Name = "Invoice")]
        public int? InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }

        //one to Many Relationship. One Customer can have many ChargeBacks
        //These two lines represent the many side
        [Display(Name = "Guest")]
        public int? CustomerGuestID { get; set; }
        public virtual CustomerGuest CustomerGuest { get; set; }
    }
}
