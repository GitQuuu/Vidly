using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required( ErrorMessage = "Please enter customers name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        //MembershipType is called navigation property
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership type")]
        public byte MemberShipTypeId { get; set; }

        [Display(Name = "Date of birth")]
        [Min18YearsIfAMember]
        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }
    }
}