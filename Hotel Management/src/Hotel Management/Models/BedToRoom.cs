using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class BedToRoom
    {

        public int ID { get; set; }

        [Display(Name = "Quantity")]
        public int Quanitity { get; set; }

        //one to Many Relationship. One RoomType can have many BedTypes
        //These two lines represent the many side
        [Display(Name = "Room Type")]
        public int? RoomTypeID { get; set; }
        public virtual RoomType RoomType { get; set; }

        //one to Many Relationship. One BedType can have many RoomTypes
        //These two lines represent the many side
        [Display(Name = "Bed Type")]
        public int?  BedTypeID { get; set; }
        public virtual BedType BedType { get; set; }
    }
}
