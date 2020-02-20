using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject.Models
{
    public class Destination
    {
        [Key]
        public int DestinationId { get; set; }
        public string DestinationName { get; set; }

        public ICollection<Trip> Trip { get; set; }
    }
}