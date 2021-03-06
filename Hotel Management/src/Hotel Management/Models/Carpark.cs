﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class Carpark
    {
        public int ID { get; set; }

        [Display(Name = "Number")]
        public string CarparkNumber { get; set; }

        [Display(Name = "Located")]
        public string CarparkLocation { get; set; }

        [Display(Name = "Name Displayed")]
        public string CarparkName { get; set; }

        //one to Many Relationship. One Hotel can have many Carparks
        //These two lines represent the many side
        //int? makes it optional (or able to be null) which is helpful when we key in the input - not a strict represntation of our ERD
        [Display(Name = "Hotel")]
        public int? HotelID { get; set; }
        public virtual Hotel Hotel { get; set; }

        //one to Many Relationship. One carpark can have many Availabilities on different dates
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<CarParkAvailability> CarParkAvailability { get; set; }

        //one to Many Relationship. One CarPark can have many CarparkBookings
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<CarparkBooking> CarparkBooking { get; set; }

    }
}
