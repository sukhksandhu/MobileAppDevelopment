using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PassionProject.Models
{
    public class Trip
    {
        [Key]
        public int TripId{ get; set; }
        public int TripCost { get; set; }

        public DateTime TripDate { get; set; }//'YYYY-MM-DD hh:mm:ss' format.
        public int DestinationId { get; set; }
        [ForeignKey("DestinationId")]
      
        public virtual Destination Destination { get; set; }

        public ICollection<TripxTraveler> TripxTraveler { get; set; }

    }
}