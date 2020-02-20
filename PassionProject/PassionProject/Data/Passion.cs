using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PassionProject.Data
{
    public class Passion :DbContext
    {
        public Passion() : base("name=Passion")
        {
        }

        public System.Data.Entity.DbSet<PassionProject.Models.Trip> Trips { get; set; }
        public System.Data.Entity.DbSet<PassionProject.Models.Destination> Destinations { get; set; }
      
        public System.Data.Entity.DbSet<PassionProject.Models.Traveler> Travelers { get; set; }


    }
}
