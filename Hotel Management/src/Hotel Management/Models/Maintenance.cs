using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class Maintenance
    {
        public int ID { get; set; }

        [Display(Name = "Maintenance Subject")]
        public string MaintenanceName { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateEntered { get; set; }

        [Display(Name = "Maintenance Details")]
        public string MaintenanceDescription { get; set; }

        [Display(Name = "Maintenance Notes")]
        public string MaintenanceNotes { get; set; }

        [Display(Name = "Completed")]
        public bool MaintenanceCompleted { get; set; }

        //one to Many Relationship. One Staff can lodge  many Maintenance Requests
        //These two lines represent the many side
        public int? StaffID { get; set; }
        public virtual Staff Staff { get; set; }

        //one to Many Relationship. One Room can have  many Maintenance Requests
        //These two lines represent the many side
        public int? RoomID { get; set; }
        public virtual Room Room { get; set; }
    }
}
