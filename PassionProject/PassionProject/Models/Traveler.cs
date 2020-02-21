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
        //primary key
        public string TravelerfName { get; set; }
        //first name of traveler
        public string TravelerlName { get; set; }
        //last name of traveler
        public string TravelerContact { get; set; }
        //contact information used string type because user can put contact number in different formats 
        public int Guests { get; set; }
        //describes for how many guests traveer is booking the trip
        public string TravelerEmail { get; set; }
        //string type for email of traveler
        public ICollection<Trip> Trips { get; set; }
        //defining one traveller to manny trips
    }
}