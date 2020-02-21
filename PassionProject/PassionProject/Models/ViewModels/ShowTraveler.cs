using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProject.Models.ViewModels
{
    public class ShowTraveler
    {
        public virtual Traveler traveler { get; set; }
        //a list for every trip 
        public List<Trip> trips { get; set; }

        //a SEPARATE list for representing the ADD of a traveler to a trip,
        
        public List<Trip> all_trips { get; set; }
    }
}