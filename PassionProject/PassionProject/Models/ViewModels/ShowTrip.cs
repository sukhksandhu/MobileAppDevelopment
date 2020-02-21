using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProject.Models.ViewModels
{
    //code referenced from https://github.com/christinebittle/PetGroomingMVC 
    //for the purpose of class assignment , dated 19 February, 2020 for Passion Project
    public class ShowTrip
    {
        public virtual Trip trip { get; set; }

        //a list for every traveler 
        public List<Traveler> travelers { get; set; }
    }
}