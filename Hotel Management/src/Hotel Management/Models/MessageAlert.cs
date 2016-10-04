using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class MessageAlert
    {
        public int ID { get; set; }

        [Display(Name = "Subject")]
        public string MessageAlertTitle { get; set; }

        [Display(Name = "Message")]
        public string MessageAlertMessage { get; set; }

        [Display(Name = "Date Message Received")]
        public DateTime MessageAlertDateReceived { get; set; }

        [Display(Name = "Date Message Delivered")]
        public DateTime MessageAlertDateDelivered { get; set; }

        [Display(Name = "Message Actioned")]
        public bool MessageAlertDelivered { get; set; }

        [Display(Name = "Notes")]
        public string CMessageAlertNotes { get; set; }

        //one to Many Relationship. One Guest can have many Message Alerts
        //These two lines represent the many side
        //int? makes it optional (or able to be null) which is helpful when we key in the input - not a strict represntation of our ERD
        public int? CustomerGuestID { get; set; }
        public virtual CustomerGuest CustomerGuest { get; set; }
    }
}

