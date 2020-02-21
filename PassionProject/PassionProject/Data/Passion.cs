using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PassionProject.Data
{
    //code referenced from https://github.com/christinebittle/PetGroomingMVC 
    //for the purpose of class assignment , dated 19 February, 2020 for Passion Project
    public class Passion :DbContext
    {
        public Passion() : base("name=Passion")//this is added to the connection string the web.config file
        {
        }
        //this file is initializing connections and creating tables in the database 
        public System.Data.Entity.DbSet<PassionProject.Models.Trip> Trips { get; set; }
        //trips table in database 
        public System.Data.Entity.DbSet<PassionProject.Models.Destination> Destinations { get; set; }
      //table destinations in the database is created 
        public System.Data.Entity.DbSet<PassionProject.Models.Traveler> Travelers { get; set; }
        //travelers table is created 

    }
}
