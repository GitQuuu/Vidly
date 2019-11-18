using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool dispose)
        {
            _context.Dispose();
        }
        
        // GET: Customers
        public ViewResult Index()
        {
            var customerInDb = _context.Customers.ToList();

            return View(customerInDb);
        }

        public ActionResult Delete(int Id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerInDb.Id)
            {
                
            }

            return RedirectToAction("Index", "Customers");
        }
    }
}