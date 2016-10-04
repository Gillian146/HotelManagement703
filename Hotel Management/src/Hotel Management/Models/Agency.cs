using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class Agency
    {
        public int ID { get; set; }

        [Display(Name = "Agency")]
        public string AgencyName { get; set; }

        [Display(Name = "Agency Contact Person")]
        public string AgencyContactName { get; set; }

        [Display(Name = "Address")]
        public string AgencyAddress { get; set; }

        [Display(Name = "Suburb")]
        public string AgencySuburb { get; set; }

        [Display(Name = "City")]
        public string AgencyCity { get; set; }

        [Display(Name = "Cell Phone")]
        public string AgencyCellPhoneNumber { get; set; }

        [Display(Name = "Work Phone")]
        public string AgencyWorkPhone { get; set; }

        [Display(Name = "Email")]
        public string AgencyEmail { get; set; }

        //one to Many Relationship. One agency has many customers
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<CustomerGuest> CustomerGuest { get; set; }

    }
}
