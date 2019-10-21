using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using Microsoft.Owin.Security.DataHandler;

namespace Vidly.Models
{
    public class MembershipType
    {
        [Column(Order = 0)]
        public byte Id { get; set; }
        [Required]
        [StringLength(30)]
        [Column(Order = 1)]
        public string Name { get; set; }
        [Column(Order = 2)]
        public short SignUpFee { get; set; }
        [Column(Order = 3)]
        public byte DurationInMonth { get; set; }
        [Column(Order = 4)]
        public byte DiscountRate { get; set; }

        public static readonly int Unknown = 0;

        public static readonly int PasAsYouGo = 1;

        public static readonly int Monthly = 2;

        public static readonly int Quarterly = 3;

        public static readonly int Annually = 4;




    }
}