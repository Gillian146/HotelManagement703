using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    public class BedType
    {
        public int ID { get; set; }
        public string  BedType { get; set; }
        public string BedTypeNotes { get; set; }

        //one to Many Relationship. One BedType can be in many Rooms
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<BedToRoom> BedToRoom { get; set; }
    }
}
