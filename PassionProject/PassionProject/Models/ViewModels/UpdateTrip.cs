using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProject.Models.ViewModels
{
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