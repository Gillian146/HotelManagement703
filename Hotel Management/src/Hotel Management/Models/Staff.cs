using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class Staff
    {
        public int ID { get; set; }
        [Display (Name = "First Name")]
        public string StaffFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string StaffLastName { get; set; }

        [Display(Name = "Address")]
        public string StaffAddress { get; set; }

        [Display(Name = "Suburb")]
        public string StaffSuburb { get; set; }

        [Display(Name = "City")]
        public string StaffCity { get; set; }

        [Display(Name = "Cell Phone")]
        public string StaffCellPhoneNumber { get; set; }

        [Display(Name = "Home Phone")]
        public string StaffHomePhone { get; set; }

        [Display(Name = "Email")]
        public string StaffEmail { get; set; }

        [Display(Name = "Photo")]
        //This will hold the file pathway to access the uploaded photo
        public string StaffPhoto { get; set; }

        //one to Many Relationship. One hotel has many staff
        //These two lines represent the many side
        //int? makes it optional (or able to be null) which is helpful when we key in the input - not a strict represntation of our ERD
        public int? HotelID { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
