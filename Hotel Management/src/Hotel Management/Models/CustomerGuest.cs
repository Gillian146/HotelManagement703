using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class CustomerGuest
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string CustomerLastName { get; set; }

        //FullName string is computed

        [Display(Name = "Address")]
        public string CustomerAddress { get; set; }

        [Display(Name = "Suburb")]
        public string CustomerSuburb { get; set; }

        [Display(Name = "City")]
        public string CustomerCity { get; set; }

        [Display(Name = "Cell Phone")]
        public string CustomerCellPhoneNumber { get; set; }

        [Display(Name = "Home Phone")]
        public string CustomerHomePhone { get; set; }

        [Display(Name = "Email")]
        public string CustomerEmail { get; set; }

        //still need relationship with Carpark???


        //one to Many Relationship. One Agency can have many Customer
        //These two lines represent the many side
        //int? makes it optional (or able to be null) which is helpful when we key in the input - not a strict represntation of our ERD
        public int? AgencyID { get; set; }
        public virtual Agency Agency { get; set; }

        //one to Many Relationship. One Guest can have many Message Alerts
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<MessageAlert> MessageAlert { get; set; }

        //one to Many Relationship. One Guest can have many Alarms
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Alarm> Alarm { get; set; }

        //one to Many Relationship. One Customer can have many Bookings
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Booking> Booking { get; set; }

        //one to Many Relationship. One Guest can have many ChargeBacks
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<ChargeBack> ChargeBack { get; set; }
    }
}
