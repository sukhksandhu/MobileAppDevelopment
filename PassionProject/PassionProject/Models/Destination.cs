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
        //defining the integer destinationid as the primary key
        public string DestinationName { get; set; }
        //defining the destination name
        public ICollection<Trip> Trip { get; set; }
        //defines the relation one destination to many trips
    }
}