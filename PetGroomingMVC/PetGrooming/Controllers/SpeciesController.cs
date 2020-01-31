using System;
using System.Collections.Generic;
using System.Data;
//required for SqlParameter class
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetGrooming.Data;
using PetGrooming.Models;
using System.Diagnostics;
namespace PetGrooming.Controllers
{
    public class SpeciesController : Controller
    {

        private PetGroomingContext db = new PetGroomingContext();
        // GET: Species
        public ActionResult Index()
        {
            return View();
        }

        //TODO: Each line should be a separate method in this class
        // List
        public ActionResult List()
         {
            List<Species> myspecies = db.Species.SqlQuery("select * from species").ToList();
            return View(myspecies);
        }
        // Show
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Pet pet = db.Pets.Find(id); //EF 6 technique
            Species Species = db.Species.SqlQuery("select * from species where speciesid=@SpeciesID", new SqlParameter("@SpeciesID", id)).FirstOrDefault();
            if (Species == null)
            {
                return HttpNotFound();
            }
            return View(Species);
        }
        // Add
        public ActionResult Add()
        {
            //STEP 1: PUSH DATA!
            //What data does the Add.cshtml page need to display the interface?
            //A list of species to choose for a pet

            //alternative way of writing SQL -- will learn more about this week 4
            //List<Species> Species = db.Species.ToList();

            List<Species> species = db.Species.SqlQuery("select * from Species").ToList();

            return View(species);
        }

        // [HttpPost] Add
        [HttpPost]
        public ActionResult Add(string Name)
        {
            //STEP 1: PULL DATA! The data is access as arguments to the method. Make sure the datatype is correct!
            //The variable name  MUST match the name attribute described in Views/Pet/Add.cshtml

            //Tests are very useul to determining if you are pulling data correctly!
            //Debug.WriteLine("Want to create a pet with name " + PetName + " and weight " + PetWeight.ToString()) ;

            //STEP 2: FORMAT QUERY! the query will look something like "insert into () values ()"...
            string query = "insert into Species (Name) values (@Name)";
            SqlParameter[] sqlparams = new SqlParameter[1]; //0,1,2,3,4 pieces of information to add
            //each piece of information is a key and value pair
            sqlparams[0] = new SqlParameter("@Name", Name);
           
            //db.Database.ExecuteSqlCommand will run insert, update, delete statements
            //db.Species.SqlCommand will run a select statement, for example.
            db.Database.ExecuteSqlCommand(query, sqlparams);


            //run the list method to return to a list of species so we can see our new one!
            return RedirectToAction("List");
        }
        // Update
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Pet pet = db.Pets.Find(id); //EF 6 technique
            Species Species = db.Species.SqlQuery("select * from species where speciesid=@speciesid", new SqlParameter("@SpeciesID", id)).FirstOrDefault();
            if (Species == null)
            {
                return HttpNotFound();
            }
            return View(Species);

        }
        // [HttpPost] Update
        [HttpPost]
        public ActionResult Update(int id, string Name)
        {
            string query = "update species set Name = @Name where SpeciesID = @id";
            SqlParameter[] sqlparams = new SqlParameter[2];
            sqlparams[0] = new SqlParameter("@Name", Name);
            sqlparams[1] = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query,sqlparams);
            return RedirectToAction("list");
        }

        // (optional) delete
        /*
         * string query = "delete from species where speciesid = @id";
         * new Swl("@id",id);
         */
        public ActionResult Delete(int id)
        {
            
            string query = "delete from Species where speciesid = @id";
            SqlParameter sqlparams = new SqlParameter("@id",id); 
           

            
            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("List");
        }

    }
}