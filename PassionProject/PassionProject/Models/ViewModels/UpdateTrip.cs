using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProject.Models.ViewModels
{
    public class UpdateTrip
    {
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