using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Hotel_Management.Models
{
    public class State
    {
        public int ID { get; set; }

        [Display(Name = "Description")]
        public String StateDescription { get; set; }
    }
}
