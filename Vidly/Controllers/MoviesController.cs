using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            Movie movie = new Movie() {Name = "Shrek!"};

            return View(movie);
            // Anomynous objects can be considered as temporarily objects we use inline
            //return RedirectToAction("Index", "Home", new {page = "1", sortBy = "Name"});
        }
    }
}