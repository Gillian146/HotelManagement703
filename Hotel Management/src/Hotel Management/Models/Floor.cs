using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class Floor
    {
        public int ID { get; set; }

        [Display(Name = "Floor Number")]
        public int FloorNumber { get; set; }

        [Display(Name = "Floor Name")]
        public string FloorName { get; set; }

        //one to Many Relationship. One hotel has many floors
        //These two lines represent the many side
        public int? HotelID { get; set; }
        public virtual Hotel Hotel { get; set; }

        //one to Many Relationship. One Floor can have many Rooms
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Room> Room { get; set; }
    }
}
