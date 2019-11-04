using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //Get customer
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        // Get specific customer
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
              return customer;
            }
        }

        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

                return customer;
            }
        }

        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Customer customerInDb = _context.Customers.SingleOrDefault(c=> c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                customerInDb.Name = customerInDb.Name;
                customerInDb.Id = customerInDb.Id;
                customerInDb.Birthdate = customerInDb.Birthdate;
                customerInDb.IsSubscribedToNewsletter = customerInDb.IsSubscribedToNewsletter;
                customerInDb.MemberShipTypeId = customerInDb.MembershipType;

                _context.SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            Customer customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();
            }
        }
    }
}
