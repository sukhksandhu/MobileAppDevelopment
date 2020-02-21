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
        //primary key integer type Trip id
        public int TripCost { get; set; }
        //cost in cents
        public DateTime TripDate { get; set; }//'YYYY-MM-DD hh:mm:ss' format.
        public int DestinationId { get; set; }
        [ForeignKey("DestinationId")]
      //defining the foreign key destination id inside trip table
        public virtual Destination Destination { get; set; }

        public ICollection<Traveler>Travelers { get; set; }
        //defining one trip to manny travellers(many to many relationship with travelers and trips

    }
}