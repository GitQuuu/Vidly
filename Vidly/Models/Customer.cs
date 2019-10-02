using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        //MembershipType is called navigation property
        public MembershipType MembershipType { get; set; }
        public byte MemberShipTypeId { get; set; }
        public DateTime Birthday { get; set; }
    }
}