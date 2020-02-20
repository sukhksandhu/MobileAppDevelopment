using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProject.Models.ViewModels
{
    public class ShowTraveler
    {
        public virtual Traveler traveler { get; set; }
        //a list for every pet they own
        public List<Trip> trips { get; set; }

        //a SEPARATE list for representing the ADD of an owner to a pet,
        //i.e. show a dropdownlist of all pets, with cta "Add Pet" on Show Owner etc.
        public List<Trip> all_trips { get; set; }
    }
}