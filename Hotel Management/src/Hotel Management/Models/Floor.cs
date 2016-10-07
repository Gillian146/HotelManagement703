using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    public class Floor
    {
        public int ID { get; set; }
        public int FloorNumber { get; set; }
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
