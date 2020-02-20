using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PassionProject.Models;

namespace PassionProject.Controllers
{
    public class TravelerController : Controller
    {
        // GET: Traveler
        public ActionResult Index()
        {
            return View();
        }
    }
}