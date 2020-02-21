using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProject.Models.ViewModels
{
    //code referenced from https://github.com/christinebittle/PetGroomingMVC 
    //for the purpose of class assignment , dated 19 February, 2020 for Passion Project
    public class UpdateTrip
    {
        //this is used while updating the trip where we need both destination information and trip info
        public Trip trip
        {
            get;
            set;
        }
        public List<Destination> dest
        {
            get; set;
        }
    }
}