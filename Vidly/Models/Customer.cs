using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        //MembershipType is called navigation property
        public MembershipType MembershipType { get; set; }
        public byte MemberShipTypeId { get; set; }
    }
}