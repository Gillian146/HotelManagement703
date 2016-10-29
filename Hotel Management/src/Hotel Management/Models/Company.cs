using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class Company
    {
        public int ID { get; set; }

        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Display(Name = "Company Contact Person")]
        public string CompanyContactName { get; set; }

        [Display(Name = "Address")]
        public string CompanyAddress { get; set; }

        [Display(Name = "Suburb")]
        public string CompanySuburb { get; set; }

        [Display(Name = "City")]
        public string CompanyCity { get; set; }

        [Display(Name = "Cell Phone")]
        public string CompanyCellPhoneNumber { get; set; }

        [Display(Name = "Work Phone")]
        public string CompanyyWorkPhone { get; set; }

        [Display(Name = "Email")]
        public string CompanyEmail { get; set; }

        //one to Many Relationship. One Company has many customers
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<CustomerGuest> CustomerGuest { get; set; }

    }
}
