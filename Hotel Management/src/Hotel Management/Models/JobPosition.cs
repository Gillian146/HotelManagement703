using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class JobPosition
    {
        public int ID { get; set; }

        [Display(Name = "Job Title")]
        public string JobPositionName { get; set; }

        [Display(Name = "Hourly Rate")]
        public string JobPositionHourlyRate { get; set; }

        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }

       

        //one to Many Relationship. One JobPosition could be held by many staff
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Staff> Staff { get; set; }


    }
}
