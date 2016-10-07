using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    public class RoomType
    {
        public int ID { get; set; }
        public string  RoomTypeName { get; set; }
        public int RoomTypeNotes { get; set; }

        //one to Many Relationship. One Floor can have many RoomTypes
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<Room> Room { get; set; }

        //one to Many Relationship. One RoomType can have many Beds
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<BedToRoom> BedToRoom { get; set; }
    }
}
