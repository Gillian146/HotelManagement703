using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class BedType
    {
        public int ID { get; set; }

        [Display(Name = "Bed Type")]
        public string  BedTypeName { get; set; }

        [Display(Name = "Bed Type Notes")]
        public string BedTypeNotes { get; set; }

        //one to Many Relationship. One BedType can be in many Rooms
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<BedToRoom> BedToRoom { get; set; }
    }
}
