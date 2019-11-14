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

            //return HttpNotFound();
        }
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        

        public ActionResult Edit(int id)
        {
            return Content("Id" +id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format($"pageIndex = {pageIndex} & sortBy =  {sortBy}"));
        }
    }
}