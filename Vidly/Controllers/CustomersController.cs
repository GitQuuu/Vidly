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
            var viewModel = new CustomerFormViewModel
            {
                // by creating this new customer its default value will be initialize to 0, and when the hidden field in Customerform is rendered it will have the value 0 instad of null
                Customer = new Customer(),
                MembershipTypes = membershiptypes
            };
            viewModel.H2Tag = "New Customer";
           
            return View("CustomerForm",viewModel);
        }
        public ActionResult Edit(int id)
        {
            //We need to get the customer with the this id from the db
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            // if the givin customer excist in the db it will return if not we want to check for that
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                // otherwise use this customer and render its form, the model behind the action "new" model is CustomerFormViewModel 
                var viewModel = new CustomerFormViewModel
                {
                    //set customer to this object
                    Customer = customer,
                    //initialize membershiptype
                    MembershipTypes = _context.MembershipType.ToList()
                };
                viewModel.H2Tag = "Edit Customer";
                // rename "new" to customerForm pass it to our viewModel
                return View("CustomerForm", viewModel);
            }
        }

        // Apply this dataAnnotation/attribute to this action to make sure it only can be called with HttpPost and not HttpGet, as a best practice if your action is modifying data make sure it can only be called by post and not by get
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            // If modelstate is not true, we will return the user back to the CustomerForm
            if (!ModelState.IsValid)
            {
                CustomerFormViewModel viewmodel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()
                };

                return View("CustomerForm", viewmodel);
            }
            // if customer. Id is == 0 we have a new customer and thats because our customer db starts from 1 which means if its zero it does not excist
            if (customer.Id == 0)
            {
                
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
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