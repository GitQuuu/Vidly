using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // we need a DB context to access our database
        private ApplicationDbContext _context;

        // and we need to initialize it as our class constructor
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            List<MembershipType> membershiptypes = _context.MembershipType.ToList();
            var viewModel = new newCustomerViewModel
            {
                MembershipTypes = membershiptypes
            };
            return View(viewModel);
        }

        // Aplly this dataAnnotion/attribute to this action to make sure it only can be called with HttpPost and not HttpGet
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            return View();
        }

        // GET: Customers
        public ViewResult Index()
        {
            // include is for eager loading, so we can tie others classes together for our views
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            // include is for eager loading, so we can tie others classes together our views
            Customer customer = _context.Customers.Include( c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

    }
}