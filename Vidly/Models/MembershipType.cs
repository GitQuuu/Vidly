using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string DurationInMonth { get; set; }
        public int SignUpFee { get; set; }
        public int DiscountRate { get; set; }   

    }
}