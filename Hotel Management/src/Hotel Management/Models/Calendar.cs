using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Management.Models
{
    public class Calendar
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }

        //one to Many Relationship. One CalendarDate can have many Rooms
        //This is the 'one' side of the code required for that relationship
        public virtual ICollection<CalendarToRoom> CalendarToRoom { get; set; }
    }
}
