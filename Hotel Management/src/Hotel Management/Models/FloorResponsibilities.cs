using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class FloorResponsibilities
    {
        public int ID { get; set; }

        //one to Many Relationship. One Floor has many FloorResponsibilites
        //These two lines represent the many side
        public int? FloorID { get; set; }
        public virtual Floor Floor { get; set; }

        //one to Many Relationship. One JobPosition has many  FloorResponsibilites
        //These two lines represent the many side
        public int? JobPositionID { get; set; }
        public virtual JobPosition JobPosition { get; set; }
    }
}
