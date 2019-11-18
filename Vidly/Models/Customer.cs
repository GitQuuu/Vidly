using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public bool IsSubscribe { get; set; }
    }
}