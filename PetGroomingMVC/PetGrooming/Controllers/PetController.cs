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
using PetGrooming.Models.ViewModels;
using System.Diagnostics;

namespace PetGrooming.Controllers
{
    public class PetController : Controller
    {
        
        private PetGroomingContext db = new PetGroomingContext();

        // GET: Pet
        public ActionResult List()
        {
            
            var pets = db.Pets.SqlQuery("Select * from Pets").ToList();
            return View(pets);
        }
        //tried with making form in list view and submitting to this method in pet controller
        //shown some errors regarding form
        //public ActionResult ListSearched(String searchkey)
        //{

        //    var pets = db.Pets.SqlQuery("Select * from Pets where lower(PetName) like %searchkey% ").ToList();
        //    return View(pets);
        //}


        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Pet pet = db.Pets.SqlQuery("select * from pets where petid=@PetID", new SqlParameter("@PetID",id)).FirstOrDefault();
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        //THE [HttpPost] Means that this method will only be activated on a POST form submit to the following URL
        //URL: /Pet/Add
        [HttpPost]
        public ActionResult Add(string PetName, Double PetWeight, String PetColor, int SpeciesID, string PetNotes)
        {
            //STEP 1: PULL DATA! 
            //parametes are kept same as name in views 
            //STEP 2: FORMAT QUERY! 
            string query = "insert into pets (PetName, Weight, color, SpeciesID, Notes) values (@PetName,@PetWeight,@PetColor,@SpeciesID,@PetNotes)";
            SqlParameter[] sqlparams = new SqlParameter[5]; 
          
            sqlparams[0] = new SqlParameter("@PetName",PetName);
            sqlparams[1] = new SqlParameter("@PetWeight", PetWeight);
            sqlparams[2] = new SqlParameter("@PetColor", PetColor);
            sqlparams[3] = new SqlParameter("@SpeciesID", SpeciesID);
            sqlparams[4] = new SqlParameter("@PetNotes",PetNotes);
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");
        }


        public ActionResult Add()
        {

            List<Species> species = db.Species.SqlQuery("select * from Species").ToList();

            return View(species);
        }

       
        //Update 
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            Pet Pet = db.Pets.SqlQuery("select * from pets where petid=@petid", new SqlParameter("@PetID", id)).FirstOrDefault();
            List<Species> species = db.Species.SqlQuery("select * from species").ToList();
            
            UpdatePet viewmodel = new UpdatePet();
            viewmodel.pet = Pet;
            viewmodel.species = species;
            if (Pet == null)
            {
                return HttpNotFound();
            }
            return View(viewmodel);

        }
        //[HttpPost] Update
        [HttpPost]
        public ActionResult Update(int id, string PetName, Double Weight, String Color,string Notes, int SpeciesID)
        {
            string query = "update pets set PetName = @PetName,Weight = @Weight,Color = @Color,Notes = @Notes,SpeciesID = @SpeciesID where PetID = @id";
            SqlParameter[] sqlparams = new SqlParameter[6];
            sqlparams[0] = new SqlParameter("@id", id);
            sqlparams[1] = new SqlParameter("@PetName", PetName);
            sqlparams[2] = new SqlParameter("@Weight",Weight);
            sqlparams[3] = new SqlParameter("@Color", Color);
            sqlparams[4] = new SqlParameter("@Notes", Notes);
            sqlparams[5] = new SqlParameter("@SpeciesID", SpeciesID);
            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("list");
        }
        //delete the pet from the list 
        public ActionResult Delete(int id)
        {

            string query = "delete from Pets where petid = @id";
            SqlParameter sqlparams = new SqlParameter("@id", id);



            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("List");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
