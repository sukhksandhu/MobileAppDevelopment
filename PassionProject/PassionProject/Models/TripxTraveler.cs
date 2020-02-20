using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PassionProject.Models
{
    public class TripxTraveler
    {
        [Key]
        public int TripxTravelerId { get; set; }
        public int TripId { get; set; }
        [ForeignKey("TripId")]
        public virtual Trip Trip { get; set; }
        public int TravelerId { get; set; }
        [ForeignKey("TravelerId")]
        public virtual Traveler Traveler { get; set; }
    }
}