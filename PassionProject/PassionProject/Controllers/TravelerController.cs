using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using PassionProject.Models;
using System.Data.Entity;
using PassionProject.Data;
using System.Data;
using System.Net;
using System.Diagnostics;
using PassionProject.Models.ViewModels;

namespace PassionProject.Controllers
{
    public class TravelerController : Controller
    {
        private Passion db = new Passion();

        // GET: GroomService/List
        public ActionResult List()
        {
            //How could we modify this to include a search bar?
            List<Traveler> travelers = db.Travelers.SqlQuery("Select * from Travelers").ToList();
            return View(travelers);

        }
        public ActionResult Add()
        {

            return View();
        }
        // GET: Traveler
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show(int id)
        {
            //find data about the individual owner
            string main_query = "select * from Travelers where TravelerId = @id";
            var pk_parameter = new SqlParameter("@id", id);
            Traveler traveler = db.Travelers.SqlQuery(main_query, pk_parameter).FirstOrDefault();

           
            string aside_query = "select * from Trips inner join TravelerTrips on Trips.TripId = TravelerTrips.Trip_TripId where TravelerTrips.Traveler_TravelerId=@id";
            var fk_parameter = new SqlParameter("@id", id);
            List<Trip> TravelerTrips = db.Trips.SqlQuery(aside_query, fk_parameter).ToList();

            string all_trips_query = "select * from Trips";
            List<Trip> alltrips = db.Trips.SqlQuery(all_trips_query).ToList();

            //ViewModel is a hybrid of three classifications of information
            //(1) showing the classic owner data
            //(2) showing all pets that owner has
            //(3) showing all pets in general (for ADD)
            ShowTraveler viewmodel = new ShowTraveler();
            viewmodel.traveler = traveler;
            viewmodel.trips = TravelerTrips;
            viewmodel.all_trips = alltrips;

            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Add(string TravelerfName, string TravelerlName, string TravelerContact, int Guests,string TravelerEmail)
        {
            string query = "insert into Travelers (TravelerfName, TravelerlName, TravelerContact, Guests, TravelerEmail) values (@TravelerfName, @TravelerlName, @TravelerContact, @Guests, @TravelerEmail)";

            SqlParameter[] sqlparams = new SqlParameter[5];
            sqlparams[0] = new SqlParameter("@TravelerfName", TravelerfName);
            sqlparams[1] = new SqlParameter("@TravelerlName", TravelerlName);
            sqlparams[2] = new SqlParameter("@TravelerContact", TravelerContact);
            sqlparams[3] = new SqlParameter("@Guests", Guests);
            sqlparams[4] = new SqlParameter("@TravelerEmail", TravelerEmail);


            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");
        }
    }
}