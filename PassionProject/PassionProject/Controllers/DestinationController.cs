using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PassionProject.Models;
using System.Data.Entity;
using PassionProject.Data;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Diagnostics;


namespace PassionProject.Controllers
{
    public class DestinationController : Controller
    {
        private Passion db = new Passion();
        // GET: Destination
        public ActionResult Index()
            //default created you can right click here and create view page the name should be 
            //same as Property name , here in this case is Index
        {
            return View();
        }
        public ActionResult List()//this is linked to list page in views where it shows all the destinations
        {
            List<Destination> dest = db.Destinations.SqlQuery("select * from destinations").ToList();
            return View(dest);
        }

        public ActionResult Add()//Add.cshtml in view shows execution of this property
        {
           

            List<Destination> dest = db.Destinations.SqlQuery("select * from Destinations").ToList();

            return View(dest);
        }
        [HttpPost]
        public ActionResult Add(string DestinationName)
        {
            //this property executes when user clicks add button in the form which has post method
            //when user clicks add it takes the data from the page filed out by user and insert into the database table
            
            string query = "insert into Destinations (DestinationName) values (@DestinationName)";
            SqlParameter[] sqlparams = new SqlParameter[1]; 
         
            sqlparams[0] = new SqlParameter("@DestinationName", DestinationName);

           
            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("List");
        }
        
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Destination destination = db.Destinations.SqlQuery("select * from Destinations where DestinationId=@DestinationId", new SqlParameter("@DestinationId", id)).FirstOrDefault();
            if (destination == null)
            {
               return HttpNotFound();
            }
            return View(destination);

        }
        [HttpPost]
        public ActionResult Update(int id, string DestinationName)
        {
            string query = "update destinations set DestinationName = @DestinationName where DestinationId = @DestinationId";
            SqlParameter[] sqlparams = new SqlParameter[2];
            sqlparams[0] = new SqlParameter("@DestinationName", DestinationName);
            sqlparams[1] = new SqlParameter("@DestinationId", id);
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("list");
        }
        public ActionResult Delete(int id)
        {

            string query = "delete from Destinations where DestinationId = @DestinationId";
            SqlParameter sqlparams = new SqlParameter("@DestinationId", id);



            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("List");
        }


    }
}