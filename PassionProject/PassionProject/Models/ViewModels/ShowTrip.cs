using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassionProject.Models.ViewModels
{
    public class ShowTrip
    {
        public virtual Trip trip { get; set; }

     
        public List<Traveler> travelers { get; set; }
    }
}