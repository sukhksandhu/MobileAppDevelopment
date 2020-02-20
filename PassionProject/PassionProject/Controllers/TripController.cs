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
    public class TripController : Controller
    {
        private Passion db = new Passion();
        // GET: Trip
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult List()
        {

            var trips = db.Trips.SqlQuery("Select * from Trips").ToList();
            return View(trips);
        }
        public ActionResult Add()
        {

            List<Destination> dest = db.Destinations.SqlQuery("select * from Destinations").ToList();

            return View(dest);
        }
        [HttpPost]
        public ActionResult Add(DateTime TripDate, int DestinationId, int TripCost)
        {
            //STEP 1: PULL DATA! 
            //parametes are kept same as name in views 
            //STEP 2: FORMAT QUERY! 
            string query = "insert into Trips (TripCost, TripDate, DestinationId) values (@TripCost,@TripDate,@DestinationId)";
            SqlParameter[] sqlparams = new SqlParameter[3];

            sqlparams[0] = new SqlParameter("@TripCost", TripCost);
            sqlparams[1] = new SqlParameter("@TripDate", TripDate);
            sqlparams[2] = new SqlParameter("@DestinationId", DestinationId);
          
            
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");
        }
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Trip trip = db.Trips.SqlQuery("select * from trips where TripId=@TripId", new SqlParameter("@TripId", id)).FirstOrDefault();
            List<Destination> dest = db.Destinations.SqlQuery("select * from Destinations").ToList();

            UpdateTrip viewmodel = new UpdateTrip();
            viewmodel.trip = trip;
            viewmodel.dest = dest;
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(viewmodel);

        }
        [HttpPost]
        public ActionResult Update(int id, DateTime TripDate, int DestinationId, int TripCost)
        {
            string query = "update trips set TripDate = @TripDate,DestinationId = @DestinationId,TripCost = @TripCost  where TripId = @id";
            SqlParameter[] sqlparams = new SqlParameter[4];
            sqlparams[0] = new SqlParameter("@id", id);
            sqlparams[1] = new SqlParameter("@TripDate", TripDate);
            sqlparams[2] = new SqlParameter("@DestinationId", DestinationId);
            sqlparams[3] = new SqlParameter("@TripCost", TripCost);
           
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("list");
        }
        public ActionResult Delete(int id)
        {

            string query = "delete from Trips where TripId = @TripId";
            SqlParameter sqlparams = new SqlParameter("@TripId", id);



            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("List");
        }

    }
}