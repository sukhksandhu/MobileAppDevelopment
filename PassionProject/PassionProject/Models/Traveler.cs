using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject.Models
{
    public class Traveler
    {
       
        public int TravelerId { get; set; }
        public string TravelerfName { get; set; }
        public string TravelerlName { get; set; }
        public string TravelerContact { get; set; }
        public int Guests { get; set; }
        public string TravelerEmail { get; set; }
        public ICollection<TripxTraveler> TripxTraveler { get; set; }
    }
}