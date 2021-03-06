﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class Alarm
    {
        public int ID { get; set; }

        [Display(Name = "Subject")]
        public string AlarmTitle { get; set; }

        [Display(Name = "Date Message Received")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AlarmDateReceived { get; set; }

        [Display(Name = "Alarm Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AlarmDate { get; set; }

        [Display(Name = "Alarm Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        public DateTime AlarmTime { get; set; }

        [Display(Name = "Alarm Actioned")]
        public bool AlarmDelivered { get; set; }

        [Display(Name = "Notes")]
        public string AlarmAlertNotes { get; set; }

        //one to Many Relationship. One Guest can request many Alarms
        //These two lines represent the many side
        //int? makes it optional (or able to be null) which is helpful when we key in the input - not a strict represntation of our ERD
        [Display(Name = "Guest")]
        public int? CustomerGuestID { get; set; }
        public virtual CustomerGuest CustomerGuest { get; set; }
    }
}