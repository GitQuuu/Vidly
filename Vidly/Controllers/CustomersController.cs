using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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

        
        public ActionResult Delete(int id)
        {
            Customer customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {

                throw new HttpRequestException(HttpStatusCode.NotFound.ToString());
            }
            else
            {
                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Create(int id)
        {
            List<MembershipType> membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerForm
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }
    }
}