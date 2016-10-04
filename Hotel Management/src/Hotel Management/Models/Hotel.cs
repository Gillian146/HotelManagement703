using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        [Display(Name = "Name")]
        public string HotelName { get; set; }

        [Display(Name = "Street Address")]
        public string HotelStreetAddress { get; set; }

        [Display(Name = "Postal Address")]
        public string HotelPostalAddress { get; set; }

        [Display(Name = "City")]
        public string HotelCity { get; set; }

        //one to Many Relationship. One hotel has many staff
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Staff> Staff { get; set; }


    }
}
